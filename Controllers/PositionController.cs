using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.DAL.Repository;
using AgencyManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManagerCoreAngular2.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class PositionController : Controller
    {
        private readonly PositionRepository _positionRepository;

        public PositionController(PositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery]PositionRepository.PositionCriteria criteria)
        {
            var result = _positionRepository.GetPositions(criteria).Select(Position => new
            {
                Id = Position.Id,
                ContactId = Position.ContactId,
                Title = Position.Title,
                Responsibilities = Position.Responsibilities,
                Skills = Position.Skills,
            });

            return Ok(result.ToArray());
        }

        //public IEnumerable<Object> GetFiltered([FromUri]PositionRepository.PositionCriteria criteria)
        //{
        //    var result = PositionRepository.GetPositions(criteria).Select(Position => new
        //    {
        //        Id = Position.Id,
        //        Time = Position.Time,
        //        Notes = Position.Notes,
        //        ContactId = Position.ContactId,
        //    });

        //    return result.ToArray();
        //}

        // GET: api/Agency/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public void Post([FromBody]Position value)
        {
            if (value.Id == 0)
            {
                _positionRepository.InsertPosition(value);
            }
            else
            {
                _positionRepository.UpdatePosition(value);
            }

            _positionRepository.Save();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Agency/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _positionRepository.DeletePosition(id);
            _positionRepository.Save();
        }
    }
}