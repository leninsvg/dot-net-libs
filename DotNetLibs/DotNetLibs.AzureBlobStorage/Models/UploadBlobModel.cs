﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLibs.AzureBlobStorage.Models
{
    public class UploadBlobModel
    {
        public string Name { get; set; }
        public byte[] Blob { get; set; }
    }
}