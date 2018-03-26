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
    public class ConversationController : Controller
    {
        private readonly ConversationRepository _conversationRepository;

        public ConversationController(ConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        [HttpGet("{ContactId}")]
        public IActionResult Get([FromQuery]ConversationRepository.ConversationCriteria criteria)
        {
            var result = _conversationRepository.GetConversations(criteria).Select(Conversation => new
            {
                Id = Conversation.Id,
                Time = Conversation.Time,
                Notes = Conversation.Notes,
                ContactId = Conversation.ContactId,
            });

            return Ok(result.ToArray());
        }

        //public IEnumerable<Object> GetFiltered([FromUri]ConversationRepository.ConversationCriteria criteria)
        //{
        //    var result = ConversationRepository.GetConversations(criteria).Select(Conversation => new
        //    {
        //        Id = Conversation.Id,
        //        Time = Conversation.Time,
        //        Notes = Conversation.Notes,
        //        ContactId = Conversation.ContactId,
        //    });

        //    return result.ToArray();
        //}

        // GET: api/Agency/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public void Post([FromBody]Conversation value)
        {
            if (value.Id == 0)
            {
                _conversationRepository.InsertConversation(value);
            }
            else
            {
                _conversationRepository.UpdateConversation(value);
            }

            _conversationRepository.Save();
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
            _conversationRepository.DeleteConversation(id);
            _conversationRepository.Save();
        }
    }
}