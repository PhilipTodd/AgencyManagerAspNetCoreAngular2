using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Interview
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
        public int ContactId { get; set; }
        public int PositionId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public Contact Contact { get; set; }
        public Position Position { get; set; }
    }
}
