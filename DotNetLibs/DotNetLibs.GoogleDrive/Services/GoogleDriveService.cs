using DotNetLibs.GoogleDrive.Models;
using DotNetLibs.GoogleDrive.Utils.Enums;
using Google.Apis.Drive.v3;
using System.Collections.Generic;

namespace DotNetLibs.GoogleDrive.Services
{
    public interface GoogleDriveService
    {
        GoogleDriveFileModel GetFile(string fileId);
        List<GoogleDriveFileModel> GetFiles(GoogleDriveFileTypeEnum fileType, string fileName);
        GoogleDriveFileModel CreateFolder(string folderName, List<string> parents);
        GoogleDriveFileModel UploadGoogleDriveFile(GoogleDriveFileModel googleDriveFile);
        void RemoveFile(string googleDriveFileId);
        DriveService GetGoogleDriveService();
    }
}
