using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class ContactRepository : IDisposable
    {
        private AgencyManagerContext context;

        public ContactRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public class ContactCriteria
        {
            public int AgentId { get; set; }
        }

        //public IEnumerable<Contact> GetContacts()
        //{
        //    return context.Contacts.ToList();
        //}

        public IEnumerable<Contact> GetContacts(ContactCriteria criteria)
        {
            IQueryable<Contact> query = context.Contacts;

            if(criteria.AgentId > 0)
            {
                query = query.Where(contact => contact.AgentId == criteria.AgentId);
            }

            query = query.OrderByDescending(contact => contact.LastName);

            return query.ToList();
        }

        public Contact GetContactByID(int id)
        {
            return context.Contacts.Find(id);
        }

        public void InsertContact(Contact Contact)
        {
            context.Contacts.Add(Contact);
        }

        public void DeleteContact(int ContactID)
        {
            Contact Contact = context.Contacts.Find(ContactID);
            context.Contacts.Remove(Contact);
        }

        public void UpdateContact(Contact Contact)
        {
            context.Entry(Contact).State = EntityState.Modified;
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