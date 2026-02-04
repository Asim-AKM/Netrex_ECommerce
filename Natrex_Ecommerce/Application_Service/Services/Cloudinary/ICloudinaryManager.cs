using Microsoft.AspNetCore.Http;

namespace Application_Service.Services.Cloudinary
{
    public interface ICloudinaryManager
    {
        Task<CloudinaryUploadResult> UploadImageAsync(IFormFile file, string folder);
        Task<List<CloudinaryUploadResult>> UploadMultipleImagesAsync(List<IFormFile> files, string folder);

        Task<bool> DeleteImageAsync(string publicId);
        Task<bool> DeleteMultipleImagesAsync(List<string> publicIds);
    }

}
