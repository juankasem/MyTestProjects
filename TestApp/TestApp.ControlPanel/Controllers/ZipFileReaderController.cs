using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TestApp.ControlPanel.Models;
using System.Text;

namespace TestApp.ControlPanel.Controllers
{
    public class ZipFileReaderController : Controller
    {
        private string _username;
        private string _password;
        private string _iv;
        private string _key;
        private IHostingEnvironment _env;
        private IConfiguration _configuration;
        private static readonly HttpClient client = new HttpClient();

        public ZipFileReaderController(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;

            //Reads User Credentials & Keys from appsettings.json file
            _username = _configuration.GetValue<string>("Logging:Username");
            _password = _configuration.GetValue<string>("Logging:Password");
            _iv = _configuration.GetValue<string>("Logging:iv");
            _key = _configuration.GetValue<string>("Logging:Key");
        }

        public IActionResult ProcessFileAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> ProcessFileAsync(string username, string password, ICollection<IFormFile> files)
        {
            var message = await UploadFileAsync(username, password,files);
            var jsonFiles = ConvertZippedFilesToJSON(files);
            var encryptedFiles = EncryptFilesAsAES(jsonFiles.ToString());     
            var response = await SendFileToDataManagementAsync(encryptedFiles);

            return response;
        }


        [HttpPost("UploadFile")]
        [Produces("application/json")]
        public async Task<IActionResult> UploadFileAsync(string username, string password, ICollection<IFormFile> files)
        {
            _username = username;
            _password = password;

            try
            {
                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        string path = Path.Combine(_env.WebRootPath, "ZippedFiles");
                        if (!Directory.Exists(path))                        
                            Directory.CreateDirectory(path);
                       
                        using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fs);
                        }
                        //Return Message                        
                        return Content("Success");
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        public ICollection<IFormFile> ConvertZippedFilesToJSON(ICollection<IFormFile> files)
        {
            foreach (var file in files)
            {
                JsonSerializer serializer = new JsonSerializer();
                Stream stream = (Stream)files;
                using (StreamWriter sw = new StreamWriter(stream))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, files);
                }
            }

            return files;
        }

        public string EncryptFilesAsAES(string jsonFolder)
        {
            byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(jsonFolder);
            AesCryptoServiceProvider encryptor = new AesCryptoServiceProvider();
            encryptor.BlockSize = 128;
            encryptor.KeySize = 256;
            encryptor.Key = ASCIIEncoding.ASCII.GetBytes(_key);
            encryptor.IV = ASCIIEncoding.ASCII.GetBytes(_iv);
            encryptor.Padding = PaddingMode.PKCS7;
            encryptor.Mode = CipherMode.CBC;

            ICryptoTransform icrypto = encryptor.CreateEncryptor(encryptor.Key, encryptor.IV);

            byte[] enc = icrypto.TransformFinalBlock(textBytes, 0, textBytes.Length);
            icrypto.Dispose();

            return Convert.ToBase64String(enc);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> SendFileToDataManagementAsync(string path)
        {
            var url = "http://localhost:49252/api/DataReader/ReadAndStoreDecryptedFilesAsync";
            var filepath = path;

            //Creates an instance of HttpContent class to fill it with file contents
            HttpContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filepath));

            try
            {
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(fileContent, "file", "filename");

                    //call api service
                    HttpResponseMessage response = await client.PostAsync(url, formData);

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("Please check the Uri", ex);
            }
        }
    }
}