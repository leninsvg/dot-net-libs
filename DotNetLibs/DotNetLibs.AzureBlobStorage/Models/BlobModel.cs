using System.ComponentModel.DataAnnotations;

namespace DotNetLibs.AzureBlobStorage.Models
{
    public class BlobModel
    {
        /// <summary>
        /// Principal path for blob files
        /// </summary>
        [Required]
        public string ContainerName { get; set; }
        /// <summary>
        /// Name of file that contains this extension. This name can be contains '/'
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
