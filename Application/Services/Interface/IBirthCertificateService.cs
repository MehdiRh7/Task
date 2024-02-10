using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IBirthCertificateService 
    {
        BirthCertificate GetByUserID(int userId);
    }
}
