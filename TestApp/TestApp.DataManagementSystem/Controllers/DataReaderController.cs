using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestApp.DataManagementSystem.Authentication;
using TestApp.DataManagementSystem.Services;

namespace TestApp.DataManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataReaderController : ControllerBase
    {
        private IHostingEnvironment _env;
        private IZippedFileService _zippedFileService;
        private string username = Thread.CurrentPrincipal.Identity.Name;

        public DataReaderController(IHostingEnvironment env, IZippedFileService zippedFileService)
        {
            _env = env;
            _zippedFileService = zippedFileService;
        }

        [BasicAuthentication]
        [HttpPost]
        public async Task<IActionResult> ReadAndStoreDecryptedFilesAsync()
        {
            if (!String.IsNullOrEmpty(username))
            {
                ICollection<IFormFile> files = await _zippedFileService.ReadEncryptedJSONAsync();

                try
                {
                    if (files != null)
                    {
                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                string path = Path.Combine(_env.WebRootPath, "DecryptedFiles");

                                using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fs);
                                }     
                            }                    
                        }

                        //Return file                        
                        return Ok(new { count = files.Count });
                    }
                    else
                        return NotFound();           
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
                return Unauthorized();
        }
    }
}
