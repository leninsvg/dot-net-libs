using DotNetLibs.AzureBlobStorage.Models;
using DotNetLibs.AzureBlobStorage.Utils.Exceptions;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.IO;

namespace DotNetLibs.AzureBlobStorage.Services.Impl
{
    public partial class AzureBlobStorageServiceImpl : AzureBlobStorageService
    {
        private const string ERROR_CONECTION = "Ocurrio un problema al intentar estableser la conexion con azure storage";
        private readonly AzureBlobStorageSettingModel _azureBlobStorageSetting;
        private CloudBlobContainer _cloudBlobContainer;
        public AzureBlobStorageServiceImpl(AzureBlobStorageSettingModel azureBlobStorageSetting)
        {
            this._azureBlobStorageSetting = azureBlobStorageSetting;
        } 
        
        private void ConnectToAzure(string containerName)
        {
            CloudStorageAccount storageAccount;
            if (!CloudStorageAccount.TryParse(this._azureBlobStorageSetting.ConnectionString, out storageAccount))
            {
                throw new AzureBlobStorageException(ERROR_CONECTION);
            }
            this.InitContainer(storageAccount, containerName);
        }

        private void InitContainer(CloudStorageAccount storageAccount, string containerName)
        {
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            this._cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            if (cloudBlobClient.GetContainerReference(containerName).Exists())
            {               
                return;
            }
            this._cloudBlobContainer.Create();
            BlobContainerPermissions permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            };
            this._cloudBlobContainer.SetPermissions(permissions);

        }
        public string UploadBlob(UploadBlobModel uploadBlob)
        {
            this.ConnectToAzure(uploadBlob.ContainerName);
            Stream fileStream = new MemoryStream(uploadBlob.Blob);
            CloudBlockBlob cloudBlockBlob = this._cloudBlobContainer.GetBlockBlobReference(uploadBlob.Name);
            cloudBlockBlob.UploadFromStream(fileStream);
            string url  = cloudBlockBlob.Uri.AbsoluteUri;
            return url;
        }
    }
}
