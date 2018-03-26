using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Position
    {
        public Position()
        {
            Contacts = new HashSet<Contact>();
            Contracts = new HashSet<Contract>();
            Documents = new HashSet<Document>();
            Interviews = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Title { get; set; }
        public string Responsibilities { get; set; }
        public string Skills { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public Contact Contact { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Interview> Interviews { get; set; }
    }
}
