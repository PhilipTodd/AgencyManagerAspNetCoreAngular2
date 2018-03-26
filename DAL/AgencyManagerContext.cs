using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgencyManager.Models
{
    public partial class AgencyManagerContext : DbContext
    {
        public virtual DbSet<AddressCompany> AddressCompany { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyCategory> CompanyCategories { get; set; }
        public virtual DbSet<ContactCategory> ContactCategories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=PHIL-ULTRABOOK\SYNERGY;Initial Catalog=AgencyManager;Integrated Security=True");
//            }
//        }

        public AgencyManagerContext(DbContextOptions<AgencyManagerContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressCompany>(entity =>
            {
                entity.HasKey(e => new { e.AddressesId, e.CompaniesId });

                entity.HasIndex(e => e.AddressesId)
                    .HasName("IX_Addresses_Id");

                entity.HasIndex(e => e.CompaniesId)
                    .HasName("IX_Companies_Id");

                entity.Property(e => e.AddressesId).HasColumnName("Addresses_Id");

                entity.Property(e => e.CompaniesId).HasColumnName("Companies_Id");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.AddressCompany)
                    .HasForeignKey(d => d.AddressesId)
                    .HasConstraintName("FK_dbo.AddressCompany_dbo.Addresses_Addresses_Id");

                entity.HasOne(d => d.Companies)
                    .WithMany(p => p.AddressCompany)
                    .HasForeignKey(d => d.CompaniesId)
                    .HasConstraintName("FK_dbo.AddressCompany_dbo.Companies_Companies_Id");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Number).IsRequired();

                entity.Property(e => e.PostCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Suburb).HasMaxLength(100);
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.CompanyCategoryId)
                    .HasName("IX_CompanyCategoryId");

                entity.HasIndex(e => e.IndustryId)
                    .HasName("IX_IndustryId");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);

                entity.HasOne(d => d.CompanyCategory)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CompanyCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Companies_dbo.CompanyCategories_CompanyCategoryId");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Companies_dbo.Industries_IndustryId");
            });

            modelBuilder.Entity<CompanyCategory>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ContactCategory>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.AgentId)
                    .HasName("IX_AgentId");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("IX_CompanyId");

                entity.HasIndex(e => e.ContactCategoryId)
                    .HasName("IX_ContactCategoryId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_Position_Id");

                entity.Property(e => e.ContactType).HasMaxLength(10);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("Position_Id");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Agents_AgentId");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Companies_CompanyId");

                entity.HasOne(d => d.ContactCategory)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contacts_dbo.ContactCategories_ContactCategoryId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Positions_Position_Id");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasIndex(e => e.CompanyId)
                    .HasName("IX_CompanyId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_PositionId");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contracts_dbo.Companies_CompanyId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contracts_dbo.Positions_PositionId");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasIndex(e => e.ContactId)
                    .HasName("IX_ContactId");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Conversations_dbo.Contacts_ContactId");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasIndex(e => e.CompanyId)
                    .HasName("IX_CompanyId");

                entity.HasIndex(e => e.ContractId)
                    .HasName("IX_ContractId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_PositionId");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.UploadTime).HasColumnType("datetime");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Documents_dbo.Companies_CompanyId");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Documents_dbo.Contracts_ContractId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Documents_dbo.Positions_PositionId");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.HasIndex(e => e.ContactId)
                    .HasName("IX_ContactId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_PositionId");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Interviews_dbo.Contacts_ContactId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Interviews_dbo.Positions_PositionId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasIndex(e => e.ContactId)
                    .HasName("IX_ContactId");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Positions_dbo.Contacts_ContactId");
            });
        }
    }
}
