using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataManagementSystem.Repos
{
    public interface IZippedFileRepo
    {
        Task<ICollection<IFormFile>> GetZippedFilesAsync();
        Task<ICollection<IFormFile>> DecryptJSONAsync(HttpResponseMessage message);
    }
}
