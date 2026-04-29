using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranApi.WebApi.Context;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ChefsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChef([FromBody] Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteChef(int id)
        {
            var find = _context.Chefs.Find(id);
            _context.Chefs.Remove(find);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetChef(int id)
        {
            var find = _context.Chefs.Find(id);
            return Ok(find);
        }
        [HttpPut]
        public IActionResult UpdateChef([FromBody] Chef chef)
        {
            var find = _context.Chefs.Find(chef.ChefId);
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }

    }
}
