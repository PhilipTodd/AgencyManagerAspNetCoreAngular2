using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class AddressRepository : IDisposable
    {
        private AgencyManagerContext context;

        public AddressRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Address> GetAddresss()
        {
            return context.Addresses.ToList();
        }

        public Address GetAddressByID(int id)
        {
            return context.Addresses.Find(id);
        }

        public void InsertAddress(Address Address)
        {
            context.Addresses.Add(Address);
        }

        public void DeleteAddress(int AddressID)
        {
            Address Address = context.Addresses.Find(AddressID);
            context.Addresses.Remove(Address);
        }

        public void UpdateAddress(Address Address)
        {
            context.Entry(Address).State = EntityState.Modified;
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