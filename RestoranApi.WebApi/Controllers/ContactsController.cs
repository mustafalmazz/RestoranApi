using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranApi.WebApi.Context;
using RestoranApi.WebApi.Dtos.ContactDtos;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var list = _context.Contacts.ToList();
            return Ok(list);
        }
        [HttpPost]  //manuel mapleme işlemi
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                MapLocation = createContactDto.MapLocation,
                Address = createContactDto.Address,
                OpenHours = createContactDto.OpenHours,
                Email = createContactDto.Email,
                Phone = createContactDto.Phone
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İşlem Başarılı!!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var find = _context.Contacts.Find(id);
            _context.Contacts.Remove(find);
            _context.SaveChanges();
            return Ok("İşlem Başarılı!!");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var oneContact = _context.Contacts.Find(id);
            return Ok(oneContact);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.Id = updateContactDto.Id;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Address = updateContactDto.Address;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.Email = updateContactDto.Email;
            contact.Phone = updateContactDto.Phone;
            _context.Contacts.Update(contact);
            return Ok("İşlem Başarılı!!");
        }
    }
}
