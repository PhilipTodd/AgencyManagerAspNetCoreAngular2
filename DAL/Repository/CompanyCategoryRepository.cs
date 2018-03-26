using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class CompanyCategoryRepository : IDisposable
    {
        private AgencyManagerContext context;

        public CompanyCategoryRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<CompanyCategory> GetCompanyCategorys()
        {
            return context.CompanyCategories.ToList();
        }

        public CompanyCategory GetCompanyCategoryByID(int id)
        {
            return context.CompanyCategories.Find(id);
        }

        public void InsertCompanyCategory(CompanyCategory CompanyCategory)
        {
            context.CompanyCategories.Add(CompanyCategory);
        }

        public void DeleteCompanyCategory(int CompanyCategoryID)
        {
            CompanyCategory CompanyCategory = context.CompanyCategories.Find(CompanyCategoryID);
            context.CompanyCategories.Remove(CompanyCategory);
        }

        public void UpdateCompanyCategory(CompanyCategory CompanyCategory)
        {
            context.Entry(CompanyCategory).State = EntityState.Modified;
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