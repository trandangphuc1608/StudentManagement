using Microsoft.AspNetCore.Authorization; // Thêm thư viện này để dùng [Authorize]
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

        // 1. LẤY DANH SÁCH SẢN PHẨM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Đã bổ sung .Include(p => p.Brand) để lấy tên Thương hiệu
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Brand)
                                 .ToListAsync();
        }

        // 2. LẤY CHI TIẾT 1 SẢN PHẨM
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                                        .Include(p => p.Category)
                                        .Include(p => p.Brand)
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