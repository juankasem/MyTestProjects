using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestApp.ControlPanel;
using TestApp.ControlPanel.Configuration;

namespace TestApp.DataManagementSystem.Repos
{
    public class ZippedFileRepo: IZippedFileRepo
    {
        public string _username;
        public string _password;
        public string _iv;
        public string _key;
        public string _url;
        private IHostingEnvironment _env;
        private static readonly HttpClient client = new HttpClient();

        public ZippedFileRepo(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<ICollection<IFormFile>> GetZippedFilesAsync()
        {
            InitializeaData();
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            ICollection<IFormFile> decryptedFiles = await DecryptJSONAsync(message);

            return decryptedFiles;
        }

        public void InitializeaData()
        {  
            _iv = DataAccessConfig.IV;
            _key = DataAccessConfig.Key;
            _url = "http://localhost:356658/ZipFileReader/SendFileToDataManagementAsync";
        }

        public async Task<HttpResponseMessage> GetHttpResponseMessageAsync()
        {
            HttpResponseMessage message = await client.GetAsync(_url);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot connect to api: { message.StatusCode} { message.ReasonPhrase}");
            }

            return message;
        }

        public async Task<ICollection<IFormFile>> DecryptJSONAsync(HttpResponseMessage message)
        {
            try
            {
                //Reads JSON file as string
                string dirsAndFiles = await message.Content.ReadAsStringAsync();

                byte[] textBytes = Convert.FromBase64String(dirsAndFiles);

                //Initializes an Encryption object & Sets values to its properties
                AesCryptoServiceProvider encryptor = new AesCryptoServiceProvider();
                encryptor.BlockSize = 128;
                encryptor.KeySize = 256;
                encryptor.Key = ASCIIEncoding.ASCII.GetBytes(_key);
                encryptor.IV = ASCIIEncoding.ASCII.GetBytes(_iv);
                encryptor.Padding = PaddingMode.PKCS7;
                encryptor.Mode = CipherMode.CBC;

                //Defines an instance of ICryptoTransform class to perform cryptographic operations 
                ICryptoTransform icrypto = encryptor.CreateEncryptor(encryptor.Key, encryptor.IV);

                byte[] enc = icrypto.TransformFinalBlock(textBytes, 0, textBytes.Length);
                icrypto.Dispose();

                string zippedFile= ASCIIEncoding.ASCII.GetString(enc);
                var result = JsonConvert.DeserializeObject<ICollection<IFormFile>>(zippedFile);

                return result;
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException("cannot convert from json", ex);
            }
        }       
    }
}
