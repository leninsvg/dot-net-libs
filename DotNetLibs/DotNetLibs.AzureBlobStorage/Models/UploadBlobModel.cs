using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetLibs.AzureBlobStorage.Models
{
    public class UploadBlobModel
    {
        [Required]
        public string ContainerName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Blob { get; set; }
    }
}
