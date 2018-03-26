using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class IndustryRepository : IDisposable
    {
        private AgencyManagerContext context;

        public IndustryRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Industry> GetIndustrys()
        {
            return context.Industries.ToList();
        }

        public Industry GetIndustryByID(int id)
        {
            return context.Industries.Find(id);
        }

        public void InsertIndustry(Industry Industry)
        {
            context.Industries.Add(Industry);
        }

        public void DeleteIndustry(int IndustryID)
        {
            Industry Industry = context.Industries.Find(IndustryID);
            context.Industries.Remove(Industry);
        }

        public void UpdateIndustry(Industry Industry)
        {
            context.Entry(Industry).State = EntityState.Modified;
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