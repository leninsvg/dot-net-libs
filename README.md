# dot-net-libs

### Google Drive

Use for use only nedd instance the object with the next structure


For get the credentials of google drive you can, go to google or use the next links:

1. https://www.iperiusbackup.net/es/activar-la-api-de-google-drive-y-obtener-las-credenciales-para-la-copia-de-seguridad/

1. https://www.iperiusbackup.net/en/how-to-enable-google-drive-api-and-get-client-credentials/

```
 GoogleDriveServiceImpl googleDriveService = new GoogleDriveServiceImpl(new DotNetLibs.GoogleDrive.Models.GoogleDriveSettings()
            {
                ApplicationName = "xxxxxx",
                ClientId = "",
                ClientSecret = ""
            });
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

Note: Google drive works with Ids for any file, in that case working with the names is stupid because you can have many files with the same name name and you can not find any diference in their files.
For this reazon google drive work with Ids.
