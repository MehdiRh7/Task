using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "کد ملی")]
        public string NIN { get; set; }

        public BirthCertificate birthCertificate { get; set; }
        public List<ProfessionalCert> professionalCert { get; set; }
        public List<Degree> degree { get; set; }
    }
}
