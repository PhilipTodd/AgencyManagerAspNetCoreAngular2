using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.DAL.Repository;
using AgencyManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ContactCategoryController : Controller
    {
        private readonly ContactCategoryRepository _contactCategoryRepository;

        public ContactCategoryController(ContactCategoryRepository contactCategoryRepository)
        {
            _contactCategoryRepository = contactCategoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_contactCategoryRepository.GetContactCategorys().ToList());
        }

        [HttpPut("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_contactCategoryRepository.GetContactCategoryByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]ContactCategory value)
        {
            if (value.Id == 0)
            {
                _contactCategoryRepository.InsertContactCategory(value);
            }
            else
            {
                _contactCategoryRepository.UpdateContactCategory(value);
            }

            _contactCategoryRepository.Save();

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
            _contactCategoryRepository.DeleteContactCategory(id);
            _contactCategoryRepository.Save();

            return Ok();
        }
    }
}