# Cloudinary Integration Guide

## Overview
Cloudinary is integrated into the Netrex E-Commerce platform for cloud-based image storage and management. This guide explains how to use Cloudinary across all modules.

---

## Setup Complete ✓

Cloudinary has been configured and is ready to use in all modules.

---

## Configuration

### appsettings.json
```json
{
  "Cloudinary": {
    "CloudName": "your-cloud-name",
    "ApiKey": "your-api-key",
    "ApiSecret": "your-api-secret"
  }
}
```

### Service Registration
Already registered in `InfrastructureDIConfigration`:
```csharp
.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"))
.AddScoped<ICloudinaryManager, CloudinaryManager>();
```

---

## Interface

### ICloudinaryManager
Located in: `Application_Service.Common.Cloudinary`
```csharp
public interface ICloudinaryManager
{
    Task<CloudinaryUploadResult> UploadImageAsync(IFormFile file, string folder);
    Task<bool> DeleteImageAsync(string publicId);
}

public class CloudinaryUploadResult
{
    public string ImageUrl { get; set; }
    public string PublicId { get; set; }
}
```

---

## How to Use

### 1. Inject ICloudinaryManager

In your Manager/Service constructor:
```csharp
public class ProductManager : IProductManager
{
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IProductRepo _productRepo;

    public ProductManager(
        ICloudinaryManager cloudinaryManager, 
        IProductRepo productRepo)
    {
        _cloudinaryManager = cloudinaryManager;
        _productRepo = productRepo;
    }
}
```

---

### 2. Upload Image
```csharp
public async Task<ApiResponse<ProductDto>> AddProductAsync(ProductDto dto, IFormFile imageFile)
{
    try
    {
        // Upload to Cloudinary
        var uploadResult = await _cloudinaryManager.UploadImageAsync(imageFile, "products");
        
        // Create entity
        var product = new Product
        {
            ProductId = Guid.NewGuid(),
            ProductName = dto.ProductName,
            ImageUrl = uploadResult.ImageUrl,      // Store URL
            ImagePublicId = uploadResult.PublicId, // Store PublicId
            // ... other fields
        };
        
        await _productRepo.AddAsync(product);
        
        return ApiResponse<ProductDto>.Success(dto, "Product added successfully");
    }
    catch (Exception ex)
    {
        return ApiResponse<ProductDto>.Fail(ex.Message);
    }
}
```

---

### 3. Update Image (Delete Old + Upload New)
```csharp
public async Task<ApiResponse<ProductDto>> UpdateProductImageAsync(Guid productId, IFormFile newImageFile)
{
    try
    {
        var product = await _productRepo.GetByIdAsync(productId);
        
        // Delete old image from Cloudinary
        if (!string.IsNullOrEmpty(product.ImagePublicId))
        {
            await _cloudinaryManager.DeleteImageAsync(product.ImagePublicId);
        }
        
        // Upload new image
        var uploadResult = await _cloudinaryManager.UploadImageAsync(newImageFile, "products");
        
        // Update entity
        product.ImageUrl = uploadResult.ImageUrl;
        product.ImagePublicId = uploadResult.PublicId;
        product.UpdatedAt = DateTime.UtcNow;
        
        await _productRepo.UpdateAsync(product);
        
        return ApiResponse<ProductDto>.Success(productDto, "Image updated successfully");
    }
    catch (Exception ex)
    {
        return ApiResponse<ProductDto>.Fail(ex.Message);
    }
}
```

---

### 4. Delete Product (with Images)
```csharp
public async Task<ApiResponse<bool>> DeleteProductAsync(Guid productId)
{
    try
    {
        var product = await _productRepo.GetByIdAsync(productId);
        var productImages = await _productImageRepo.GetByProductIdAsync(productId);
        
        // Delete all images from Cloudinary
        foreach (var image in productImages)
        {
            await _cloudinaryManager.DeleteImageAsync(image.PublicId);
        }
        
        // Delete from database
        await _productRepo.DeleteAsync(product);
        
        return ApiResponse<bool>.Success(true, "Product deleted successfully");
    }
    catch (Exception ex)
    {
        return ApiResponse<bool>.Fail(ex.Message);
    }
}
```

---

## Folder Organization by Module

Use these folder names for organizing images in Cloudinary:

| Module | Folder Name | Example Usage |
|--------|-------------|---------------|
| **Products** | `"products"` | Product images |
| **Users** | `"users"` | Profile pictures |
| **Sellers** | `"sellers"` | Seller/shop logos |
| **Invoices** | `"invoices"` | Invoice attachments (if needed) |

**Example:**
```csharp
var uploadResult = await _cloudinaryManager.UploadImageAsync(file, "products");
```

This creates the following structure in Cloudinary:
```
Cloudinary Dashboard/
├── products/
│   ├── image1.jpg
│   ├── image2.jpg
├── users/
│   ├── user1.jpg
│   ├── user2.jpg
└── sellers/
    ├── seller1.jpg
```

---

## Database Schema Changes Required

### Add PublicId field to entities that store images:

#### ProductImage Entity
```csharp
public class ProductImage
{
    public Guid ImageId { get; set; }
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string PublicId { get; set; }        // ← ADD THIS
    public bool IsPrimary { get; set; }
    public DateTime UploadedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
```

#### User Entity
```csharp
public class User
{
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePublicId { get; set; }   // ← ADD THIS
    // ... other fields
}
```

#### Seller Entity
```csharp
public class Seller
{
    public Guid SellerId { get; set; }
    public string StoreName { get; set; }
    public string LogoUrl { get; set; }
    public string LogoPublicId { get; set; }    // ← ADD THIS
    // ... other fields
}
```

---

## Migration Command

After adding PublicId fields to your entities:
```bash
dotnet ef migrations add AddPublicIdToImageEntities
dotnet ef database update
```
or 

Command for migrations:
Add-Migration UserManagementEntities -Project Infrastructure_Service -StartupProject APIGateway_Service -OutputDir Persistance/Migrations
 
For update database :
update-database -Project Infrastructure_Service -StartupProject APIGateway_Service

---

## Testing

### Test Endpoint Available

**POST** `/api/CloudinaryTest/upload-test`

Upload a test image to verify Cloudinary integration is working.

**DELETE** `/api/CloudinaryTest/delete-test?publicId=test/abc123`

Delete a test image using its publicId.

---

## Common Usage Patterns

### Pattern 1: Single Image Upload
```csharp
var uploadResult = await _cloudinaryManager.UploadImageAsync(imageFile, "products");
entity.ImageUrl = uploadResult.ImageUrl;
entity.PublicId = uploadResult.PublicId;
```

### Pattern 2: Multiple Images Upload
```csharp
foreach (var imageFile in imageFiles)
{
    var uploadResult = await _cloudinaryManager.UploadImageAsync(imageFile, "products");
    
    var productImage = new ProductImage
    {
        ImageId = Guid.NewGuid(),
        ProductId = product.ProductId,
        ImageUrl = uploadResult.ImageUrl,
        PublicId = uploadResult.PublicId
    };
    
    await _productImageRepo.AddAsync(productImage);
}
```

### Pattern 3: Update Image
```csharp
// Delete old
await _cloudinaryManager.DeleteImageAsync(entity.PublicId);

// Upload new
var uploadResult = await _cloudinaryManager.UploadImageAsync(newFile, "products");

// Update entity
entity.ImageUrl = uploadResult.ImageUrl;
entity.PublicId = uploadResult.PublicId;
```

---

## Error Handling

Always wrap Cloudinary operations in try-catch:
```csharp
try
{
    var uploadResult = await _cloudinaryManager.UploadImageAsync(file, "products");
    // ... rest of logic
}
catch (ArgumentException ex)
{
    // File is null or empty
    return ApiResponse<T>.Fail("Invalid file", ResponseType.BadRequest);
}
catch (Exception ex)
{
    // Cloudinary upload failed
    return ApiResponse<T>.Fail(ex.Message, ResponseType.InternalServerError);
}
```

---

## Important Notes

1. **Always store both `ImageUrl` and `PublicId`** in your database
   - `ImageUrl` → For displaying images in frontend
   - `PublicId` → For deleting images from Cloudinary

2. **Delete images from Cloudinary when:**
   - Updating an image (delete old, upload new)
   - Deleting an entity that has images
   - User removes their profile picture

3. **Folder naming convention:**
   - Use lowercase
   - Use plural form (products, users, sellers)
   - Keep it simple and consistent

4. **Image transformations:**
   - Currently using `Quality("auto")` and `FetchFormat("auto")`
   - Cloudinary automatically optimizes images

---

## Frontend Integration (Blazor)

### Display Image
```razor
<img src="@product.ImageUrl" alt="@product.ProductName" />
```

The `ImageUrl` from your API response is already the full Cloudinary URL - just use it directly!

---

## Support

For issues or questions about Cloudinary integration:
1. Check Cloudinary dashboard for uploaded images
2. Verify credentials in `appsettings.json`
3. Use test endpoint to verify connection
4. Contact: netrexEcommerce@gmail.com

---

## Resources

- [Cloudinary Dashboard](https://cloudinary.com/console)
- [Cloudinary .NET SDK Documentation](https://cloudinary.com/documentation/dotnet_integration)
- NuGet Package: `CloudinaryDotNet`