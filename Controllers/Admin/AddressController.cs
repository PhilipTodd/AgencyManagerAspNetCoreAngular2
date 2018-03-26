using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgencyManager.Models;
using AgencyManager.DAL.Repository;

namespace AgencyManager.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class AddressController : Controller
    {
        private readonly AddressRepository _addressRepository;

        public AddressController(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_addressRepository.GetAddresss().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_addressRepository.GetAddressByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Address value)
        {
            if (value.Id == 0)
            {
                _addressRepository.InsertAddress(value);
            }
            else
            {
                _addressRepository.UpdateAddress(value);
            }

            _addressRepository.Save();

            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _addressRepository.DeleteAddress(id);
            _addressRepository.Save();

            return Ok();
        }
    }
}