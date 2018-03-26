using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public int PositionId { get; set; }
        public int CompanyId { get; set; }
        public bool Signed { get; set; }
        public string Notes { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public Company Company { get; set; }
        public Position Position { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
