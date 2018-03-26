using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class AgentRepository : IDisposable
    {
        private AgencyManagerContext context; // = new AgencyManagerContext();

        public AgentRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Agent> GetAgents()
        {
            return context.Agents.ToList();
        }

        public Agent GetAgentByID(int id)
        {
            return context.Agents.Find(id);
        }

        public void InsertAgent(Agent Agent)
        {
            context.Agents.Add(Agent);
        }

        public void DeleteAgent(int AgentID)
        {
            Agent Agent = context.Agents.Find(AgentID);
            context.Agents.Remove(Agent);
        }

        public void UpdateAgent(Agent Agent)
        {
            context.Entry(Agent).State = EntityState.Modified;
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