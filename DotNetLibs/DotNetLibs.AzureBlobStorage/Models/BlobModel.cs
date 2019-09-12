using System.ComponentModel.DataAnnotations;

namespace DotNetLibs.AzureBlobStorage.Models
{
    public class BlobModel
    {
        [Required]
        public string ContainerName { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
