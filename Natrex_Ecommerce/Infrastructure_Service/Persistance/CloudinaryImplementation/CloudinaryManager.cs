using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain_Service.RepoInterfaces.Cloudinary;
using Infrastructure_Service.Persistance.CloudinaryImplementation.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure_Service.Persistance.CloudinaryImplementation
{
    public class CloudinaryManager : ICloudinaryManager
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryManager(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<CloudinaryUploadResult> UploadImageAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty or null");

            var uploadResult = new ImageUploadResult();

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = folder,
                    Transformation = new Transformation().Quality("auto").FetchFormat("auto")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult.Error != null)
                throw new Exception($"Cloudinary upload failed: {uploadResult.Error.Message}");

            return new CloudinaryUploadResult
            {
                ImageUrl = uploadResult.SecureUrl.ToString(),
                CloudPublicId = uploadResult.PublicId
            };
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
                return false;

            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result.Result == "ok";
        }

        public async Task<List<CloudinaryUploadResult>> UploadMultipleImagesAsync(List<IFormFile> files, string folder)
        {
            if (files == null || !files.Any())
                return new List<CloudinaryUploadResult>();

            var uploadResults = new List<CloudinaryUploadResult>();

            foreach (var file in files)
            {
                // Purane single upload function ko hi call kar rahe hain code reuse karne ke liye
                var result = await UploadImageAsync(file, folder);
                uploadResults.Add(result);
            }

            return uploadResults;
        }

        public async Task<bool> DeleteMultipleImagesAsync(List<string> publicIds)
        {
            if (publicIds == null || !publicIds.Any())
                return false;
            // Use DelResParams for batch deletion to optimize performance and reduce API round-trips.
            var delParams = new DelResParams()
            {
                PublicIds = publicIds,
                Type = "upload",
                ResourceType = ResourceType.Image
            };

            var result = await _cloudinary.DeleteResourcesAsync(delParams);

            // Verify if the deletion count is greater than zero to confirm success.
            return result.Deleted.Count > 0;
        }
    }
}

