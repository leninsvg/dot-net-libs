using DotNetLibs.CloudinaryApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLibs.CloudinaryApi.Services
{
    public interface CloudinaryApiService
    {
        void UploadImage(ImageUploadModel imageUpload);
    }
}
