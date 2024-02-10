using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Images
{
    public class ProfessionalCert_Images
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProfessionalCertID { get; set; }
        [Display(Name = "نام تصویر")]
        public string ImageName { get; set; }

        [ForeignKey(nameof(ProfessionalCertID))]
        public ProfessionalCert professionalCert { get; set; }

    }
}
