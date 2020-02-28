using System;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database
{
    public class ContactManagementDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<WorkingContract> WorkingContracts { get; set; }

        public ContactManagementDBContext(DbContextOptions<ContactManagementDBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                        .HasKey(c => c.Id);
            modelBuilder.Entity<Company>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<WorkingContract>()
                .HasKey(wc => new { wc.CompanyId, wc.ContactId });

            modelBuilder.Entity<WorkingContract>()
                .HasOne(wc => wc.Company)
                .WithMany(c => c.WorkingContracts)
                .HasForeignKey(wc => wc.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkingContract>()
                .HasOne(wc => wc.Contact)
                .WithMany(c => c.WorkingContracts)
                .HasForeignKey(wc => wc.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
