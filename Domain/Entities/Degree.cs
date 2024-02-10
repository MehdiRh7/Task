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
    public class Degree
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [Display(Name = "کد ملی")]

        public string NIN { get; set; }
        
        [Display(Name = "نام آموزشگاه")]
        public string InstitutionName { get; set; }
        [Display(Name = "مقطع")]
        public string Level { get; set; }

        public List<Degree_Images>  degree_Images { get; set; }
        [ForeignKey(nameof(UserId))]
        public Users Users { get; set; }

    }
}
