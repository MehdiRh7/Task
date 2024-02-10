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
    public class BirthCertificateService : IBirthCertificateService
    {
        private readonly IMyContext context;

        public BirthCertificateService(IMyContext context)
        {
            this.context = context;
        }

        public BirthCertificate GetByUserID(int userId)
        {
            return context.birthCertificates.Where(b => b.UserId == userId).FirstOrDefault();
        }
    }
}
