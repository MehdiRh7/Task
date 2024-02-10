using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Images
{
    public class BirthCertificate_Images
    {
        [Key]
        public int Id { get; set; }
        public int BirthCertificateID { get; set; }
        [Display(Name = "نام تصویر")]
        public string ImageName { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [ForeignKey(nameof(BirthCertificateID))]
        public BirthCertificate birthCertificate { get; set; }
    }
}
