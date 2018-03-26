using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class ContactCategory
    {
        public ContactCategory()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
