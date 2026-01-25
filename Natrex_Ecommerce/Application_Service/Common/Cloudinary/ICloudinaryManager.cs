using Microsoft.AspNetCore.Http;

namespace Application_Service.Common.Cloudinary
{
    public interface ICloudinaryManager
    {
        Task<CloudinaryUploadResult> UploadImageAsync(IFormFile file, string folder);
        Task<bool> DeleteImageAsync(string publicId);
    }

}
