using Application.Services.ContextInterface;
using Application.Services.Interface;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfessionalCertService : IProfessionalCertService
    {
        private readonly IMyContext context;

        public ProfessionalCertService(IMyContext context)
        {
            this.context = context;
        }
        public IEnumerable<ProfessionalCert> GetByUserID(int userId)
        {
            return context.professionalCert.Where(p => p.UserId == userId).ToList();
        }
    }
}
