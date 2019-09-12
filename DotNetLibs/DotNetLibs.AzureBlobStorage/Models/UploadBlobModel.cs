using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetLibs.AzureBlobStorage.Models
{
    public class UploadBlobModel: BlobModel
    {
        [Required]
        public byte[] Blob { get; set; }
    }
}
