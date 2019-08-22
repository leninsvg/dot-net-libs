using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotNetLibs.GoogleDrive.Utils.Enums
{
    public enum GoogleDriveFileTypeEnum
    {
        [Description("image/jpeg")]
        ImageJpeg,
        [Description("image/png")]
        ImagePng,
        [Description("application/vnd.google-apps.folder")]
        Folder
    }
}
