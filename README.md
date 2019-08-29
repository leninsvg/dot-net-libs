# dot-net-libs

### Google Drive

Use for use only nedd instance the object with the next structure


For get the credentials of google drive you can, go to google or use the next links:

1. https://www.iperiusbackup.net/es/activar-la-api-de-google-drive-y-obtener-las-credenciales-para-la-copia-de-seguridad/

1. https://www.iperiusbackup.net/en/how-to-enable-google-drive-api-and-get-client-credentials/


#### Instance in one class

```
 GoogleDriveServiceImpl googleDriveService = new GoogleDriveServiceImpl(new DotNetLibs.GoogleDrive.Models.GoogleDriveSettings()
 {
     ApplicationName = "xxxxxx",
     ClientId = "",
     ClientSecret = ""
 });
```

#### Using dependency inyection (In the Startup.cs)

```
 services.AddTransient<GoogleDriveServiceImpl>(x => new GoogleDriveServiceImpl(new GoogleDriveSettings() {
     ApplicationName = "xxxx",
     ClientId = "xxxx",
     ClientSecret = "xxxxx"
 }));
```

This library contains the nex methods: 

```
  GoogleDriveFileModel GetFile(string fileId);
  List<GoogleDriveFileModel> GetFiles(GoogleDriveFileTypeEnum fileType, string fileName);
  GoogleDriveFileModel CreateFolder(string folderName, List<string> parents);
  GoogleDriveFileModel UploadGoogleDriveFile(GoogleDriveFileModel googleDriveFile);
  void RemoveFile(string googleDriveFileId);
  DriveService GetGoogleDriveService();

```

##### Response has the next info (GoogleDriveFileModel)

```
  public string Id { get; set; }
  public string Name { get; set; }
  public string FileType { get; set; }
  public IList<string> Parents { get; set; }
```

Note: Google drive works with Ids for any file, in that case working with the names is stupid because you can have many files with the same name name and you can not find any diference in their files.
For this reazon google drive work with Ids.
