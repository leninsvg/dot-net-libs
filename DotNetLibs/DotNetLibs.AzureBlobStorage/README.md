# dot-net-libs

### Azure blob storage

Use for use only nedd instance the object with the next structure


#### Instance in one class

```
AzureBlobStorageServiceImpl azureBlobStorageService = new AzureBlobStorageServiceImpl(new AzureBlobStorageSettingModel()
{
	ConnectionString = "xxxxxx", // this value you can found in your account of azure in your services
})
```

#### Using dependency inyection (In the Startup.cs)

```
services.AddTransient<AzureBlobStorageService, AzureBlobStorageServiceImpl>(x => new AzureBlobStorageServiceImpl(new AzureBlobStorageSettingModel()
{
    ConnectionString = "xxxxxx", // this value you can found in your account of azure in your services
}));
```

This library contains the nex methods: 

```
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
```

##### UploadBlobModel

```
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
/// <summary>
/// bites of blob file
/// </summary>
[Required]
public byte[] Blob { get; set; }
```

Note: 
**the container name** is the principal path of images this path only can contains one subrute (Examples):
user-images
documents
**name** is the name of blob file this name can be contains subroutes (Examples):
docoment.doc
user12/document.doc
images-pablo-12/profile.png

This library is based of your oficial documentation for more informatio you can access to: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet
For more information you can access to next repository: https://github.com/Leningsv/dot-net-libs/tree/master/DotNetLibs/DotNetLibs.AzureBlobStorage
