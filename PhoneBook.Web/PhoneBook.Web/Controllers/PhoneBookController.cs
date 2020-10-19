using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Web.DTO;
using PhoneBook.Web.Model;
using PhoneBook.Web.Repository;

namespace PhoneBook.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;


        public PhoneBookController(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            this._phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }
        // GET: PhoneBookController
        [HttpGet]
        public IList<PhoneBookContact> Get()
        {
            return _phoneBookRepository.GetAllContacts();
        }


        [HttpPost]
        public IActionResult Post([FromBody] PhoneBookContactDto phoneBookContactDto)
        {
            //Check if contact exists then update, otherwise insert new.
            bool result;
            if (_phoneBookRepository.CheckifContactExists(phoneBookContactDto.Name))
            {
                //Check if the entry already exists and return 409 if true
                if (_phoneBookRepository.CheckifContactEntryExists(phoneBookContactDto))
                    return StatusCode(StatusCodes.Status409Conflict);
                result = _phoneBookRepository.UpdateContact(phoneBookContactDto);
            }
            else
                result = _phoneBookRepository.InsertContact(phoneBookContactDto);


            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] PhoneBookContactDto phoneBookContactDto)
        {
            bool result = _phoneBookRepository.DeleteContact(phoneBookContactDto);

            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }
    }
}
