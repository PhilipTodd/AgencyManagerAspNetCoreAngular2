using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Conversations = new HashSet<Conversation>();
            Interviews = new HashSet<Interview>();
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string ContactType { get; set; }
        public int? CompanyId { get; set; }
        public int? AgentId { get; set; }
        public int ContactCategoryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int? PositionId { get; set; }

        public Agent Agent { get; set; }
        public Company Company { get; set; }
        public ContactCategory ContactCategory { get; set; }
        public Position Position { get; set; }
        public ICollection<Conversation> Conversations { get; set; }
        public ICollection<Interview> Interviews { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}
