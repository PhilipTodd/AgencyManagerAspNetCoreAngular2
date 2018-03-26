using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class AddressCompany
    {
        public int AddressesId { get; set; }
        public int CompaniesId { get; set; }

        public Address Addresses { get; set; }
        public Company Companies { get; set; }
    }
}
