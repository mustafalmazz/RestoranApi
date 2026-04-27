using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranApi.WebApi.Context;
using RestoranApi.WebApi.Dtos.MessageDtos;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var find = _context.Message.ToList();

            return Ok(_mapper.Map<List<ResultMessageDto>>(find));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _context.Message.Add(value);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var find = _context.Message.Find(id);
            _context.Message.Remove(find);
            _context.SaveChanges();
            return Ok("İşlem Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var find = _context.Message.Find(id);
            return Ok(_mapper.Map<GetByIdMessage>(find));
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Message.Update(value);
            _context.SaveChanges();
            return Ok("İşlem Başarılı"); 
        }
    }
}
