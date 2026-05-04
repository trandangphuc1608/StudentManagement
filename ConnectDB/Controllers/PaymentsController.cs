using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;
using ConnectDB.Helpers; // Dùng cái bùa VnPayLibrary

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config; // Bổ sung IConfiguration để đọc file appsettings.json

        // Chích IConfiguration vào hàm tạo
        public PaymentsController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments.Include(p => p.Order).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments.Include(p => p.Order).FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null) return NotFound();
            return payment;
        }

        [HttpPost]
        public async Task<ActionResult> PostPayment(Payment payment)
        {
            // 1. Lưu phiếu thanh toán vào Database trước
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            // 2. NẾU KHÁCH CHỌN VNPAY THÌ TẠO LINK TRẢ VỀ FRONTEND
            if (payment.PaymentMethod == "VNPAY")
            {
                string url = _config["VnPay:BaseUrl"] ?? "";
                string returnUrl = _config["VnPay:ReturnUrl"] ?? "";
                string tmnCode = _config["VnPay:TmnCode"] ?? "";
                string hashSecret = _config["VnPay:HashSecret"] ?? "";

                VnPayLibrary vnpay = new VnPayLibrary();
                vnpay.AddRequestData("vnp_Version", "2.1.0");
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", tmnCode);
                vnpay.AddRequestData("vnp_Amount", (payment.Amount * 100).ToString("0"));
                DateTime vnpTime = DateTime.UtcNow.AddHours(7);
                vnpay.AddRequestData("vnp_CreateDate", vnpTime.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_ExpireDate", vnpTime.AddMinutes(15).ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1");
                vnpay.AddRequestData("vnp_Locale", "vn");
                vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang " + payment.OrderId);
                vnpay.AddRequestData("vnp_OrderType", "other");
                vnpay.AddRequestData("vnp_ReturnUrl", returnUrl);
                vnpay.AddRequestData("vnp_TxnRef", payment.Id.ToString());

                string paymentUrl = vnpay.CreateRequestUrl(url, hashSecret);

                // Trả về link để React chuyển hướng khách hàng
                return Ok(new { url = paymentUrl, paymentId = payment.Id });
            }

            // Nếu là COD hoặc phương thức khác thì trả về như bình thường
            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id) return BadRequest();

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Payments.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}