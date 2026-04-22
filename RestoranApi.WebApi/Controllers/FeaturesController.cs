using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranApi.WebApi.Context;
using RestoranApi.WebApi.Dtos.FeatureDtos;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        IMapper _mapper;
        private readonly  ApiContext _context;
        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();

            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
           
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var find = _context.Features.Find(id);
            _context.Features.Remove(find);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");

        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var find = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeature>(find));
        }
    }
}
