using Application_Service.Common.APIResponses;
using Application_Service.Services.Cloudinary;
using Domain_Service.Enums;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ICloudinaryManager _cloudinaryManager;

        public ImageController(ICloudinaryManager cloudinaryManager)
        {
            _cloudinaryManager = cloudinaryManager;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadTest(IFormFile file, [FromQuery] string folder = "general")
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(ApiResponse<CloudinaryUploadResult>.Fail("No file uploaded", ResponseType.BadRequest));

                var result = await _cloudinaryManager.UploadImageAsync(file, folder);

                return Ok(ApiResponse<CloudinaryUploadResult>.Success(result, "Image uploaded successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<CloudinaryUploadResult>.Fail(ex.Message,ResponseType.InternalServerError));
            }
        }
        [HttpPost("upload-batch")]
        public async Task<IActionResult> UploadImages(List<IFormFile> files, [FromQuery] string folder = "general")
        {
            try
            {
                if (files == null || !files.Any())
                    return BadRequest(ApiResponse<List<CloudinaryUploadResult>>.Fail("No files selected", ResponseType.BadRequest));

                // Manager ka naya batch upload function call karein
                var uploadResults = await _cloudinaryManager.UploadImagesAsync(files, folder);

                return Ok(ApiResponse<List<CloudinaryUploadResult>>.Success(uploadResults, "Images uploaded successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<CloudinaryUploadResult>>.Fail(ex.Message, ResponseType.InternalServerError));
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTest([FromQuery] string publicId)
        {
            try
            {
                if (string.IsNullOrEmpty(publicId))
                    return BadRequest(ApiResponse<bool>.Fail("PublicId is required", ResponseType.BadRequest));

                var result = await _cloudinaryManager.DeleteImageAsync(publicId);

                if (result)
                    return Ok(ApiResponse<bool>.Success(true, "Image deleted successfully"));
                else
                    return BadRequest(ApiResponse<bool>.Fail(false, "Failed to delete image", ResponseType.BadRequest));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.Fail(false, ex.Message, ResponseType.InternalServerError));
            }
        }
        [HttpDelete("delete-batch")]
        public async Task<IActionResult> DeleteImages([FromBody] List<string> publicIds)
        {
            try
            {
                if (publicIds == null || !publicIds.Any())
                    return BadRequest(ApiResponse<bool>.Fail("No PublicIds provided", ResponseType.BadRequest));

                // Yahan loop ki bajaye naya Manager method call karein jo humne batch delete ke liye banaya tha
                var result = await _cloudinaryManager.DeleteImagesAsync(publicIds);

                return Ok(ApiResponse<bool>.Success(result, "Batch delete operation completed"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.Fail(false, ex.Message, ResponseType.InternalServerError));
            }
        }
    }
}


