using InsureTech.Domain.Entities;
using InsureTech.Domain.Entities.InsureTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsureTech.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary keys
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Policy>().HasKey(p => p.Id);
            modelBuilder.Entity<PolicyType>().HasKey(pt => pt.Id);
            modelBuilder.Entity<PersonalInformation>().HasKey(pi => pi.Id);

            // Configure relationships
            modelBuilder.Entity<Policy>()
                .HasOne(p => p.PolicyType)
                .WithMany()
                .HasForeignKey(p => p.PolicyTypeId);

            modelBuilder.Entity<Policy>()
                .HasOne(p => p.PersonalInformation)
                .WithOne(pi => pi.Policy) // Assuming PolicyId in PersonalInformation
                .HasForeignKey<PersonalInformation>(pi => pi.PolicyId);
        }
    }
}
