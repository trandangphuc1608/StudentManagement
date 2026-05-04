using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LẤY DANH SÁCH SẢN PHẨM (Cho trang chủ Admin & Store)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Brand)
                                 .ToListAsync();
        }

        // 2. LẤY CHI TIẾT 1 SẢN PHẨM (Cho trang Chi tiết sản phẩm)
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                                        .Include(p => p.Category)
                                        .Include(p => p.Brand)
                                        .Include(p => p.Variants) // Bổ sung lấy danh sách Phiên bản (Màu/Dung lượng)
                                        .Include(p => p.Reviews)  // Bổ sung lấy danh sách Đánh giá
                                            .ThenInclude(r => r.User) // Móc tiếp để lấy tên Khách hàng bình luận
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound(new { message = "Không tìm thấy sản phẩm!" });

            return product;
        }

        // 3. THÊM SẢN PHẨM MỚI
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // 4. CẬP NHẬT SẢN PHẨM
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest(new { message = "ID không khớp!" });

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                    return NotFound(new { message = "Không tìm thấy sản phẩm!" });
                else
                    throw;
            }

            return NoContent();
        }

        // 5. XÓA SẢN PHẨM
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound(new { message = "Không tìm thấy sản phẩm!" });

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}