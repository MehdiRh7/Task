using Core.Domain.Entities;
using Core.Domain.Entities.Images;
using Microsoft.EntityFrameworkCore;
using Application.Services.ContextInterface;
namespace Infrastructure.Persistance.Context
{
    public class MyContext: DbContext, IMyContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)  
        {
            
        }
        public DbSet<Users> users { get; set; }
        public DbSet<BirthCertificate> birthCertificates { get; set; }
        public DbSet<BirthCertificate_Images> birthCertificatesImages { get; set; }
        public DbSet<Degree> degrees { get; set; }
        public DbSet<Degree_Images> degreeImages { get; set; }
        public DbSet<ProfessionalCert> professionalCert { get; set; }
        public DbSet<ProfessionalCert_Images> professionalCertImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirthCertificate>()
                .HasOne(p => p.Users)
                .WithOne(u => u.birthCertificate);
            modelBuilder.Entity<Users>()
                .HasOne(p => p.birthCertificate)
                .WithOne(u => u.Users);

            modelBuilder.Entity<BirthCertificate_Images>()
                .HasOne(p => p.birthCertificate)
                .WithMany(u => u.birthCertificate_Images)
                .HasForeignKey(f => f.BirthCertificateID);
            modelBuilder.Entity<ProfessionalCert>()
                .HasOne(p => p.Users)
                .WithMany(u => u.professionalCert)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Degree>()
                .HasOne(p => p.Users)
                .WithMany(u => u.degree)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Degree_Images>()
                .HasOne(p => p.degree)
                .WithMany(u => u.degree_Images)
                .HasForeignKey(f => f.DegreeID);
            modelBuilder.Entity<ProfessionalCert_Images>()
                .HasOne(p => p.professionalCert)
                .WithMany(u => u.professionalCert_Images)
                .HasForeignKey(f => f.ProfessionalCertID);

            base.OnModelCreating(modelBuilder);
        }

 
    }
}
