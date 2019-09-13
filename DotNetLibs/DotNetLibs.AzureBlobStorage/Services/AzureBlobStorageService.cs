using DotNetLibs.AzureBlobStorage.Models;

namespace DotNetLibs.AzureBlobStorage.Services
{
    public interface AzureBlobStorageService
    {
        /// <summary>
        /// Upload or override existent blob file
        /// </summary>
        /// <param name="uploadBlob"></param>
        /// <returns>url of blob file</returns>
        string UploadBlob(UploadBlobModel uploadBlob);
        /// <summary>
        /// Remove blob file
        /// </summary>
        /// <param name="containerName">Principal path for blob files</param>
        /// <param name="blobName">blob name</param>
        void RemoveBlob(string containerName, string blobName);
    }
}
