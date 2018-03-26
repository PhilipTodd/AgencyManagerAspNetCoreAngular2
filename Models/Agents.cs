using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
