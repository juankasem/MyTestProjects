using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.ControlPanel.Models
{
    public class FileUploadViewModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
