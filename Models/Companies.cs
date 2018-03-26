using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Company
    {
        public Company()
        {
            AddressCompany = new HashSet<AddressCompany>();
            Contacts = new HashSet<Contact>();
            Contracts = new HashSet<Contract>();
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public int CompanyCategoryId { get; set; }
        public int IndustryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public CompanyCategory CompanyCategory { get; set; }
        public Industry Industry { get; set; }
        public ICollection<AddressCompany> AddressCompany { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
