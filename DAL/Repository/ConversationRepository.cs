using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class ConversationRepository : IDisposable
    {
        private AgencyManagerContext context;

        public ConversationRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public class ConversationCriteria
        {
            public int ContactId { get; set; }
        }

        public IEnumerable<Conversation> GetConversations(ConversationCriteria criteria)
        {
            IQueryable<Conversation> query = context.Conversations;

            if (criteria.ContactId > 0)
            {
                query = query.Where(Conversation => Conversation.ContactId == criteria.ContactId);
            }

            query = query.OrderByDescending(Conversation => Conversation.Time);

            return query.ToList();
        }

        public Conversation GetConversationByID(int id)
        {
            return context.Conversations.Find(id);
        }

        public void InsertConversation(Conversation Conversation)
        {
            context.Conversations.Add(Conversation);
        }

        public void DeleteConversation(int ConversationID)
        {
            Conversation Conversation = context.Conversations.Find(ConversationID);
            context.Conversations.Remove(Conversation);
        }

        public void UpdateConversation(Conversation Conversation)
        {
            context.Entry(Conversation).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}