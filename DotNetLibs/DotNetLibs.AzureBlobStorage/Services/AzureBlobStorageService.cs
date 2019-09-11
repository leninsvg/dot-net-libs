using DotNetLibs.AzureBlobStorage.Models;

namespace DotNetLibs.AzureBlobStorage.Services
{
    public interface AzureBlobStorageService
    {
        string UploadBlob(UploadBlobModel uploadBlob);
    }
}
