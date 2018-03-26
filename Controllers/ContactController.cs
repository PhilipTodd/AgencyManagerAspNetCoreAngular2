using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManagerCoreAngular2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactRepository _contactRepository;

        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery]ContactRepository.ContactCriteria criteria)
        {
            var result = _contactRepository.GetContacts(criteria).Select(contact => new
            {
                Id = contact.Id,
                Name = String.Format("{0} - {1}", contact.FirstName, contact.LastName)
            });

            return Ok(result.ToArray());
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok("value");
        //}

        //// POST: api/Agency
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Agency/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Agency/5
        //public void Delete(int id)
        //{
        //}
    }
}