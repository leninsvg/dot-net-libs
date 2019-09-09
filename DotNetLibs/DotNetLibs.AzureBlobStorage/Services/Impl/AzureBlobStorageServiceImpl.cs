using DotNetLibs.AzureBlobStorage.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.IO;

namespace DotNetLibs.AzureBlobStorage.Services.Impl
{
    public partial class AzureBlobStorageServiceImpl : AzureBlobStorageService
    {
        private readonly AzureBlobStorageSettingModel _azureBlobStorageSetting;
        private CloudBlobContainer _cloudBlobContainer;
        public AzureBlobStorageServiceImpl(AzureBlobStorageSettingModel azureBlobStorageSetting)
        {
            this._azureBlobStorageSetting = azureBlobStorageSetting;
        } 
        
        private void ConnectToAzure()
        {
            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(this._azureBlobStorageSetting.ConnectionString, out storageAccount))
            {                
                this.InitContainer(storageAccount);
            }
            else
            {
                // Otherwise, let the user know that they need to define the environment variable.
                Console.WriteLine(
                    "A connection string has not been defined in the system environment variables. " +
                    "Add an environment variable named 'CONNECT_STR' with your storage " +
                    "connection string as a value.");
                Console.WriteLine("Press any key to exit the application.");
                Console.ReadLine();
            }
        }

        private void InitContainer(CloudStorageAccount storageAccount)
        {
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            this._cloudBlobContainer = cloudBlobClient.GetContainerReference("images/test/tessss");
            if (cloudBlobClient.GetContainerReference("images/test/tessss").Exists())
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
        public void UploadBlob(UploadBlobModel uploadBlob)
        {
            this.ConnectToAzure();
            Stream fileStream = new MemoryStream(uploadBlob.Blob);

            // Create storagecredentials object by reading the values from the configuration (appsettings.json)
            //StorageCredentials storageCredentials = new StorageCredentials(_azureBlobStorageSetting.AccountName, _azureBlobStorageSetting.AccountKey);

            // Create cloudstorage account by passing the storagecredentials
            //CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            // Create the blob client.
            //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get reference to the blob container by passing the name by reading the value from the configuration (appsettings.json)
            //CloudBlobContainer container = blobClient.GetContainerReference(_storageConfig.ImageContainer);

            // Get the reference to the block blob from the container
            CloudBlockBlob cloudBlockBlob = this._cloudBlobContainer.GetBlockBlobReference(uploadBlob.Name);

            // Upload the file
            cloudBlockBlob.UploadFromStream(fileStream);
            string url  = cloudBlockBlob.Uri.AbsoluteUri;

            // Get a reference to the blob address, then upload the file to the blob.
            // Use the value of localFileName for the blob name.
        }
    }
}
