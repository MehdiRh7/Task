using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities.Images;

namespace Core.Domain.Entities
{
    public class ProfessionalCert
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "نام شرکت / سازمان")]
        public string CompanyName { get; set; }
        [Display(Name = "تاریخ شروع")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاریخ خاتمه")]
        public DateTime EndDate { get; set; }
        [Display(Name = "کد ملی")]

        public string NIN { get; set; }

        public List<ProfessionalCert_Images> professionalCert_Images { get; set; }

        [ForeignKey(nameof(UserId))]
        public Users Users { get; set; }
    }
}
