using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyVaccine.WebApi.Models
{
    public class MyVaccineAppDbContext : IdentityDbContext<IdentityUser>
    {
       public MyVaccineAppDbContext(DbContextOptions<MyVaccineAppDbContext> options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<VaccineCategory> VaccineCategories { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineRecord> VaccinesRecord { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<FamilyGroup> FamilyGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AspNetUser)
                .WithMany()
                .HasForeignKey(u => u.AspNetUserId);
          

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(255);

            });
            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.Property(d => d.Name)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasOne(d => d.User)
                       .WithMany(u => u.Dependents)
                       .HasForeignKey(d => d.UserId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<VaccineCategory>(entity =>
            {
                entity.Property(vc => vc.Name)
                      .IsRequired()
                      .HasMaxLength(100);

            });
            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.Property(v => v.Name)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasMany(v => v.Categories)
                      .WithMany(vc => vc.Vaccines)
                      .UsingEntity<Dictionary<string, object>>(
                          "VaccineCategoryVaccines", // Nombre de la tabla de unión
                          j => j.HasOne<VaccineCategory>().WithMany().HasForeignKey("CategoryId"),
                          j => j.HasOne<Vaccine>().WithMany().HasForeignKey("VaccineId")
                      );
            });
            modelBuilder.Entity<VaccineRecord>(entity =>
            {
                entity.Property(vr => vr.AdministeredLocation)
                      .HasMaxLength(255);

                entity.Property(vr => vr.AdministeredBy)
                      .HasMaxLength(255);

                entity.HasOne(vr => vr.User)
                    .WithMany(u => u.VaccineRecords)
                    .HasForeignKey(vr => vr.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(vr => vr.Dependent)
                    .WithMany(d => d.VaccineRecords)
                    .HasForeignKey(vr => vr.DependentId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(vr => vr.Vaccine)
                    .WithMany()
                    .HasForeignKey(vr => vr.VaccineId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(a => a.User)
                    .WithMany(u => u.Allergies)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<FamilyGroup>(entity =>
            {
                entity.Property(fg => fg.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
