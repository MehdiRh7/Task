using Core.Domain;
using Core.Domain.Entities;
using Core.Domain.Entities.Images;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ContextInterface
{
    public interface IMyContext
    {
         DbSet<Users> users { get; set; }
         DbSet<BirthCertificate> birthCertificates { get; set; }
         DbSet<BirthCertificate_Images> birthCertificatesImages { get; set; }
         DbSet<Degree> degrees { get; set; }
         DbSet<Degree_Images> degreeImages { get; set; }
         DbSet<ProfessionalCert> professionalCert { get; set; }
         DbSet<ProfessionalCert_Images> professionalCertImages { get; set; }
         int SaveChanges();
         Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
         int SaveChanges(bool acceptAllChangesOnSuccess);
         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
