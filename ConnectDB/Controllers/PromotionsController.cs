using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PromotionsController(AppDbContext context)
        {
            _context = context;
        }

        // --- CÁC API CRUD CƠ BẢN (GIỮ NGUYÊN CỦA BẠN) ---

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
        {
            return await _context.Promotions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetPromotion(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null) return NotFound();
            return promotion;
        }

        [HttpPost]
        public async Task<ActionResult<Promotion>> PostPromotion(Promotion promotion)
        {
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPromotion", new { id = promotion.Id }, promotion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(int id, Promotion promotion)
        {
            if (id != promotion.Id) return BadRequest();

            _context.Entry(promotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Promotions.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null) return NotFound();

            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- API MỚI: KIỂM TRA MÃ GIẢM GIÁ (DÀNH CHO TRANG GIỎ HÀNG) ---

        [HttpGet("check/{code}")]
        public async Task<IActionResult> CheckPromotionCode(string code)
        {
            // Tìm mã giảm giá trong Database (không phân biệt chữ hoa/thường)
            var promotion = await _context.Promotions
                .FirstOrDefaultAsync(p => p.Code.ToLower() == code.ToLower());

            // 1. Kiểm tra mã có tồn tại không
            if (promotion == null)
                return NotFound(new { message = "Mã giảm giá không tồn tại!" });

            // 2. Kiểm tra hạn sử dụng (Ngày kết thúc < Ngày hiện tại)
            if (promotion.EndDate < DateTime.Now)
                return BadRequest(new { message = "Mã giảm giá đã hết hạn!" });

            // 3. Kiểm tra số lượng còn lại
            if (promotion.Quantity <= 0)
                return BadRequest(new { message = "Mã giảm giá đã được sử dụng hết!" });

            // 4. Nếu vượt qua mọi bài test -> Trả về thông tin để React trừ tiền
            return Ok(new
            {
                id = promotion.Id,
                code = promotion.Code,
                discountPercent = promotion.DiscountPercent,
                maxDiscount = promotion.MaxDiscountAmount
            });
        }
    }
}