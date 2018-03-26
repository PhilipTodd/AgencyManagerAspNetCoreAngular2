using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.DAL.Repository;
using AgencyManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgencyManager.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class AgentController : Controller
    {
        private AgentRepository _agentRepository;

        public AgentController(AgentRepository agentRepository)
        {
            this._agentRepository = agentRepository;
        }

        // GET: api/Agent
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            List<Agent> agents = new List<Agent>();

            _agentRepository.GetAgents().ToList().ForEach(agent =>
            {
                agents.Add(agent);
            });

            var result = agents.Select(agent =>
                new {
                    Id = agent.Id,
                    Name = agent.Name
                });

            return Ok(result.ToArray());
        }

        // GET: api/Agency/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_agentRepository.GetAgentByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Agent value)
        {
            if (value.Id == 0)
            {
                _agentRepository.InsertAgent(value);
            }
            else
            {
                _agentRepository.UpdateAgent(value);
            }

            _agentRepository.Save();

            return Ok(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _agentRepository.DeleteAgent(id);
            _agentRepository.Save();
            return Ok();
        }
    }
}
