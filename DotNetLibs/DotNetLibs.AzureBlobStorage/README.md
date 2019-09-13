# dot-net-libs

### Google Drive

Use for use only nedd instance the object with the next structure


#### Instance in one class

```
AzureBlobStorageServiceImpl googleDriveService = new AzureBlobStorageServiceImpl(new AzureBlobStorageSettingModel()
{
	ConnectionString = "xxxxxx",
})
```

#### Using dependency inyection (In the Startup.cs)

```
services.AddTransient<AzureBlobStorageService, AzureBlobStorageServiceImpl>(x => new AzureBlobStorageServiceImpl(new AzureBlobStorageSettingModel()
{
    ConnectionString = "xxxxxx",
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