using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCoupons.core.DL.Entities
{
    public class Admin : BaseEntity
    {
        [Required]
        public byte UserQRCode { get; set; }
        public int EmployeeId { get; set; } //Foreign Key

        public Byte QRCode { get; set; } 
        public Boolean IsDeleted { get; set; }
          

       public ICollection<Employee> Employees { get; set;} //Navigational Property => Many
        = new HashSet<Employee>();  
    }
}
