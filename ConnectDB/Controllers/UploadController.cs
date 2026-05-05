using Microsoft.AspNetCore.Mvc;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "Vui lòng chọn một file ảnh!" });

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
                return BadRequest(new { message = "Chỉ cho phép upload file ảnh (.jpg, .png, .webp, .gif)!" });

            // 🔥 FIX LỖI PATH1 NULL TẠI ĐÂY 🔥
            // Kiểm tra xem WebRootPath có bị null không (do Somee ẩn/chưa tạo wwwroot)
            string webRootPath = _env.WebRootPath;
            if (string.IsNullOrWhiteSpace(webRootPath))
            {
                // Nếu null, lấy đường dẫn gốc của app và tự ghép thêm chữ "wwwroot"
                webRootPath = Path.Combine(_env.ContentRootPath, "wwwroot");
            }

            // Tạo đường dẫn tới thư mục uploads
            string uploadsFolder = Path.Combine(webRootPath, "uploads");

            // Kiểm tra nếu thư mục uploads chưa tồn tại thì tự động tạo luôn
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Tạo tên file ngẫu nhiên để không bị đè file trùng tên
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Lưu file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var fileUrl = $"/uploads/{uniqueFileName}";
            return Ok(new { url = fileUrl });
        }
    }
}