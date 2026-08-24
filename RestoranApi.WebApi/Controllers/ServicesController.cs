using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranApi.WebApi.Context;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult ServiceList()
        {
            var list = _context.Services.ToList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var find = _context.Services.Find(id);
            if (find == null)
            {
                return NotFound("Silinecek servis bulunamadı");
            }
            _context.Services.Remove(find);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
