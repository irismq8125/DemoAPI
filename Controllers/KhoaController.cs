using DemoApi.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly QuanLySinhVienContext _context;
        public KhoaController(QuanLySinhVienContext context)
        {
            _context = context;
        }


        //api get all data
        [HttpGet("danh-sach-khoa-1")] 
        public IActionResult DanhSachKhoa1()
        {
            var items = _context.Khoas.ToList();
            return Ok(items);
        }

        [HttpGet("danh-sach-khoa-2")]
        public List<Khoa> DanhSachKhoa2()
        {
            var items = _context.Khoas.ToList();
            return items;
        }

        //api get 1 data
        [HttpGet("thong-tin-khoa/{id}")]
        public IActionResult ItemKhoa(string id)
        {
            var item = _context.Khoas.FirstOrDefault(x => x.Id == id);
            return Ok(item);
        }

        //api delete 1 data
        [HttpDelete("xoa-khoa/{id}")]
        public IActionResult XoaKhoa(string id)
        {
            var item = _context.Khoas.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Khoas.Remove(item);
                _context.SaveChanges();
            }
            return Ok();
        }

        //api post data
        [HttpPost("them-moi-khoa")]
        public IActionResult TaoKhoa()
        {
            return Ok();
        }

        //api put data
        [HttpPut("cap-nhat-khoa")]
        public IActionResult CapNhat()
        {
            return Ok();
        }

    }
}
