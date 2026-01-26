using Application_Service.Common.APIResponses;
using Application_Service.Common.Cloudinary;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryTestController : ControllerBase
    {
        private readonly ICloudinaryManager _cloudinaryManager;

        public CloudinaryTestController(ICloudinaryManager cloudinaryManager)
        {
            _cloudinaryManager = cloudinaryManager;
        }

        [HttpPost("upload-test")]
        public async Task<IActionResult> UploadTest(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(ApiResponse<CloudinaryUploadResult>.Fail("No file uploaded", Domain_Service.Enums.ResponseType.BadRequest));

                var result = await _cloudinaryManager.UploadImageAsync(file, "test");

                return Ok(ApiResponse<CloudinaryUploadResult>.Success(result, "Image uploaded successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<CloudinaryUploadResult>.Fail(ex.Message, Domain_Service.Enums.ResponseType.InternalServerError));
            }
        }

        [HttpDelete("delete-test")]
        public async Task<IActionResult> DeleteTest([FromQuery] string publicId)
        {
            try
            {
                if (string.IsNullOrEmpty(publicId))
                    return BadRequest(ApiResponse<bool>.Fail("PublicId is required", Domain_Service.Enums.ResponseType.BadRequest));

                var result = await _cloudinaryManager.DeleteImageAsync(publicId);

                if (result)
                    return Ok(ApiResponse<bool>.Success(true, "Image deleted successfully"));
                else
                    return BadRequest(ApiResponse<bool>.Fail(false, "Failed to delete image", Domain_Service.Enums.ResponseType.BadRequest));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.Fail(false, ex.Message, Domain_Service.Enums.ResponseType.InternalServerError));
            }
        }
    }
}

