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
    public class CompanyCategoryController : Controller
    {
        private readonly CompanyCategoryRepository _companyCategoryRepository;

        public CompanyCategoryController(CompanyCategoryRepository companyCategoryRepository)
        {
            _companyCategoryRepository = companyCategoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_companyCategoryRepository.GetCompanyCategorys().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_companyCategoryRepository.GetCompanyCategoryByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CompanyCategory value)
        {
            if (value.Id == 0)
            {
                _companyCategoryRepository.InsertCompanyCategory(value);
            }
            else
            {
                _companyCategoryRepository.UpdateCompanyCategory(value);
            }

            _companyCategoryRepository.Save();

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
            _companyCategoryRepository.DeleteCompanyCategory(id);
            _companyCategoryRepository.Save();

            return Ok();
        }
    }
}
