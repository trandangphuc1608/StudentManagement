using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.User) // <--- LẤY TÊN KHÁCH HÀNG
                .OrderByDescending(o => o.OrderDate) // Xếp đơn mới nhất lên đầu
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)           // Móc thông tin Khách hàng
                .Include(o => o.OrderItems)     // Móc danh sách chi tiết đơn
                    .ThenInclude(oi => oi.Product) // Móc lấy tên, giá của Sản phẩm trong chi tiết đơn
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            // 1. KIỂM TRA VÀ TRỪ KHO TRỰC TIẾP TRÊN BẢNG PRODUCTS
            foreach (var item in order.OrderItems)
            {
                // Tìm sản phẩm khách đang đặt mua
                var product = await _context.Products.FindAsync(item.ProductId);

                if (product == null)
                {
                    return BadRequest(new { message = $"Lỗi: Không tìm thấy sản phẩm có mã {item.ProductId}!" });
                }

                // Kiểm tra xem kho của sản phẩm này còn đủ không
                if (item.Quantity > product.StockQuantity)
                {
                    return BadRequest(new { message = $"Rất tiếc! '{product.Name}' chỉ còn {product.StockQuantity} sản phẩm. Vui lòng giảm số lượng!" });
                }

                // Đủ hàng -> Bắt đầu trừ kho
                product.StockQuantity -= item.Quantity;
            }

            // 2. NẾU VƯỢT QUA BÀI KIỂM TRA -> LƯU ĐƠN HÀNG VÀ CẬP NHẬT KHO
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id) return BadRequest();

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}