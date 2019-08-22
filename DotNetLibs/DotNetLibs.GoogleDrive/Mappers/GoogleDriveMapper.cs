using DotNetLibs.GoogleDrive.Models;
using Google.Apis.Drive.v3.Data;

namespace DotNetLibs.GoogleDrive.Mappers
{
    public static partial class Mapper
    {
        public static GoogleDriveFileModel MapFileToGoogleDriveFileModel(File file)
        {
            return new GoogleDriveFileModel()
            {
                Id = file.Id,
                Name = file.Name,
                FileType = file.MimeType,
                Parents = file.Parents
            };
        }       
    }
}
