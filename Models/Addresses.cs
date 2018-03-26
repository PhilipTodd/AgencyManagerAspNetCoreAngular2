using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Address
    {
        public Address()
        {
            AddressCompany = new HashSet<AddressCompany>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public ICollection<AddressCompany> AddressCompany { get; set; }
    }
}
