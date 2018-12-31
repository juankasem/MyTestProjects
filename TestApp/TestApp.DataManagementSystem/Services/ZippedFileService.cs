using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApp.DataManagementSystem.Repos;

namespace TestApp.DataManagementSystem.Services
{
    public class ZippedFileService : IZippedFileService
    {
        private IZippedFileRepo _repo;

        public ZippedFileService(IZippedFileRepo repo)
        {
            _repo = repo;
        }

        public async Task<ICollection<IFormFile>> ReadEncryptedJSONAsync()
        {
            ICollection<IFormFile> files = await _repo.GetZippedFilesAsync();

            return files;
        }
    }
}
