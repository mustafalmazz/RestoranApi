using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranApi.WebApi.Context;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            if (_context.Categories.ToList() != null)
            {
                return Ok(_context.Categories.ToList());
            }
            return NotFound("Kategoriler bulunamadı");
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
    }
}
