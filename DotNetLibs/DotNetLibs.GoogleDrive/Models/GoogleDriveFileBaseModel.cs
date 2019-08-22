using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLibs.GoogleDrive.Models
{
    public abstract class GoogleDriveFileBaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public abstract string FileType { get; set; }
        public IList<string> Parents { get; set; }
    }
}
