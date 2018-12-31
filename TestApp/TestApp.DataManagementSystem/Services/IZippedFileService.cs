using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataManagementSystem.Services
{
    public interface IZippedFileService
    {
        Task<ICollection<IFormFile>> ReadEncryptedJSONAsync();
    }
}
