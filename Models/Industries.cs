using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Industry
    {
        public Industry()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
