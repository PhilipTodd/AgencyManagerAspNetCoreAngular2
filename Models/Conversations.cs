using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Conversation
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
        public int ContactId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public Contact Contact { get; set; }
    }
}
