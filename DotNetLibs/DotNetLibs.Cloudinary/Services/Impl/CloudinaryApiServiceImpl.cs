using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DotNetLibs.CloudinaryApi.Models;
using System;
using System.IO;

namespace DotNetLibs.CloudinaryApi.Services.Impl
{
    public partial class CloudinaryApiServiceImpl : CloudinaryApiService
    {
        private readonly CloudinaryApiSettingModel _cloudinaryApiSetting;
        private readonly Cloudinary _cloudinary;

        public CloudinaryApiServiceImpl(CloudinaryApiSettingModel cloudinaryApiSetting)
        {
            this._cloudinaryApiSetting = cloudinaryApiSetting;
            this._cloudinary = new Cloudinary(new Account() {
                ApiKey = this._cloudinaryApiSetting.ApiKey,
                ApiSecret = this._cloudinaryApiSetting.ApiSecret,
                Cloud = this._cloudinaryApiSetting.Cloud
            });
        }

        public void UploadImage(ImageUploadModel imageUpload)
        {
            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageUpload.Name, new MemoryStream(imageUpload.Image)),
            };
            ImageUploadResult uploadResult = this._cloudinary.Upload(uploadParams);
        }
    }
}
