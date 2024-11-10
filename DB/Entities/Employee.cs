using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCoupons.core.DL.Entities
{
    public class Employee : BaseEntity
    {

        [Required]
        public String EmployeeName { get; set; } //Refered To Email
        public  Boolean IsActive { get; set; }
        [Required]
        public String Password { get; set; }

        public Admin Admins { get; set; } //Navigational Property => One


    }
}
