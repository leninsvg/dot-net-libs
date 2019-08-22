using DotNetLibs.GoogleDrive.Mappers;
using DotNetLibs.GoogleDrive.Models;
using DotNetLibs.GoogleDrive.Utils;
using DotNetLibs.GoogleDrive.Utils.Enums;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DotNetLibs.GoogleDrive.Services.Impl
{
    public partial class GoogleDriveServiceImpl
    {
        private readonly GoogleDriveSettings _googleDriveSettings;
        private readonly DriveService _driveService;
        public GoogleDriveServiceImpl(GoogleDriveSettings googleDriveSettings)
        {
            this._googleDriveSettings = googleDriveSettings;
            this._driveService = this.GetGoogleDriveService();
        }

        public GoogleDriveFileModel GetFile(string fileId)
        {
            List<GoogleDriveFileModel> googleDriveFiles = new List<GoogleDriveFileModel>();
            DriveService driveService = this.GetGoogleDriveService();
            FilesResource.GetRequest request = driveService.Files.Get(fileId);
            request.Fields = "name,parents";
            File file = request.Execute();
            return Mapper.MapFileToGoogleDriveFileModel(file);
        }

        public List<GoogleDriveFileModel> GetFiles(GoogleDriveFileTypeEnum fileType, string fileName)
        {
            List<GoogleDriveFileModel> googleDriveFiles = new List<GoogleDriveFileModel>();
            DriveService driveService = this.GetGoogleDriveService();
            FilesResource.ListRequest request = driveService.Files.List();
            request.Q = string.Format("mimeType = '{0}' and name = '{1}'", fileType.GetDescription(), fileName);
            request.Spaces = "drive";
            request.Fields = "nextPageToken, files(id, name, mimeType, parents)";
            IList<File> files = request.Execute().Files;
            foreach (File file in files)
            {
                GoogleDriveFileModel googleDriveFile = Mapper.MapFileToGoogleDriveFileModel(file);
                googleDriveFiles.Add(googleDriveFile);
            }
            return googleDriveFiles;
        }

        public GoogleDriveFileModel CreateFolder(string folderName, List<string> parents)
        {
            File fileMetadata = new File()
            {
                Name = folderName,
                MimeType = GoogleDriveFileTypeEnum.Folder.GetDescription()
            };
            fileMetadata.Parents = parents;
            FilesResource.CreateRequest request = this._driveService.Files.Create(fileMetadata);
            File file = request.Execute();
            return Mapper.MapFileToGoogleDriveFileModel(file);
        }

        public GoogleDriveFileModel UploadGoogleDriveFile(GoogleDriveFileModel googleDriveFile)
        {
            DriveService driveService = this.GetGoogleDriveService();
            File uploadGoogleDriveFile = new File()
            {
                Name = googleDriveFile.Name,
                Parents = googleDriveFile.Parents
            };
            System.IO.MemoryStream streamFile = new System.IO.MemoryStream(googleDriveFile.FileBytes);
            FilesResource.CreateMediaUpload request;
            using (streamFile)
            {
                request = driveService.Files.Create(
                    uploadGoogleDriveFile, streamFile, googleDriveFile.FileType.GetDescription());
                request.Upload();
            }
            File uploadFile = request.ResponseBody;
            return Mapper.MapFileToGoogleDriveFileModel(uploadFile);
        }


        public void RemoveFile(string googleDriveFileId)
        {
            DriveService driveService = this.GetGoogleDriveService();
            FilesResource.DeleteRequest request = driveService.Files.Delete(googleDriveFileId);
        }

        public DriveService GetGoogleDriveService()
        {
            UserCredential credential = this.GetCredentials();
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this._googleDriveSettings.ApplicationName,
            });
            return service;
        }

        private UserCredential GetCredentials()
        {
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                  new ClientSecrets
                  {
                      ClientId = this._googleDriveSettings.ClientId,
                      ClientSecret = this._googleDriveSettings.ClientSecret,
                  },
                  new[] { DriveService.Scope.Drive }, "user", CancellationToken.None).Result;
            return credential;
        }
        //public GoogleDriveFileModel UploadImage(GoogleDriveFileModel image, GoogleDriveFolderEnum googleDriveFolder)
        //{
        //    GoogleDriveFileModel folder = this.GetGoogleDriveFolder(googleDriveFolder.GetPath());
        //    if (folder == null)
        //    {
        //        folder = this.CreateGoogleDriveFolder(googleDriveFolder.GetPath());
        //    }
        //    GoogleDriveFileModel uploadImage = this.UploadGoogleDriveFile(new GoogleDriveFileModel()
        //    {
        //        FileBase64 = image.FileBase64,
        //        FileType = GoogleDriveFileTypeEnum.ImageJpeg.GetDescription(),
        //        Name = image.Name,
        //        Parents = new List<string>() { folder.Id }
        //    });
        //    return uploadImage;
        //}
    }
}
