namespace DotNetLibs.GoogleDrive.Models
{
    public class GoogleDriveFileModel : GoogleDriveFileBaseModel
    {
        public byte[] FileBytes { get; set; }
        public override string FileType { get; set; }
    }
}
