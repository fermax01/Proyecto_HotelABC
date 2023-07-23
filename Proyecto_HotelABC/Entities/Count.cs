using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HotelABC.Entities
{
    public class Count
    {
        [Key]
        public int PkCount { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        


        [ForeignKey("Roles")]
        public int? FkRole { get; set; }
        public Role Roles { get; set; }
    }
}
