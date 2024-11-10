using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCoupons.core.DL.Entities
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; } //Pk

        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public String UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }


    }
}
