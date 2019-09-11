using DotNetLibs.AzureBlobStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLibs.AzureBlobStorage.Services
{
    public interface AzureBlobStorageService
    {
        string UploadBlob(UploadBlobModel uploadBlob);
    }
}
