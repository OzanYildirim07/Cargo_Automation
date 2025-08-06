using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
    [Table("Admin_Information")]
    public class Admin_Information
    {

        [Key]
        public string Admin_Username { get; set; }
        public string Admin_Password { get; set; }
    }
}
