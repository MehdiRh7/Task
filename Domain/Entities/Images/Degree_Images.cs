using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Images
{
    public class Degree_Images
    {
        [Key]
        public int Id { get; set; }
        public int DegreeID { get; set; }
        public int UserId { get; set; }
        [Display(Name = "نام تصویر")]
        public string ImageName { get; set; }

        [ForeignKey(nameof(DegreeID))]
        public Degree degree { get; set; }
    }
}
