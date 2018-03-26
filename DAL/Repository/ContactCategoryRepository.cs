using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class ContactCategoryRepository : IDisposable
    {
        private AgencyManagerContext context;

        public ContactCategoryRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<ContactCategory> GetContactCategorys()
        {
            return context.ContactCategories.ToList();
        }

        public ContactCategory GetContactCategoryByID(int id)
        {
            return context.ContactCategories.Find(id);
        }

        public void InsertContactCategory(ContactCategory ContactCategory)
        {
            context.ContactCategories.Add(ContactCategory);
        }

        public void DeleteContactCategory(int ContactCategoryID)
        {
            ContactCategory ContactCategory = context.ContactCategories.Find(ContactCategoryID);
            context.ContactCategories.Remove(ContactCategory);
        }

        public void UpdateContactCategory(ContactCategory ContactCategory)
        {
            context.Entry(ContactCategory).State = EntityState.Modified;
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