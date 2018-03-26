using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.DAL.Repository;
using AgencyManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManagerCoreAngular2.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class IndustryController : Controller
    {
        private readonly IndustryRepository _industryRepository;

        public IndustryController(IndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        [HttpGet]
        public IEnumerable<Industry> Get()
        {
            return _industryRepository.GetIndustrys().ToList();
        }

        [HttpPut("{id}")]
        public Industry Get(int id)
        {
            return _industryRepository.GetIndustryByID(id);
        }

        [HttpPost]
        public void Post([FromBody]Industry value)
        {
            if (value.Id == 0)
            {
                _industryRepository.InsertIndustry(value);
            }
            else
            {
                _industryRepository.UpdateIndustry(value);
            }

            _industryRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _industryRepository.DeleteIndustry(id);
            _industryRepository.Save();
        }
    }
}