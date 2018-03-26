using System;
using System.Collections.Generic;

namespace AgencyManager.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UploadTime { get; set; }
        public byte Data { get; set; }
        public string Notes { get; set; }
        public int PositionId { get; set; }
        public int CompanyId { get; set; }
        public int ContractId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public Company Company { get; set; }
        public Contract Contract { get; set; }
        public Position Position { get; set; }
    }
}
