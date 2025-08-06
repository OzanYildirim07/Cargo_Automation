using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
     
    
        [Table("Personal_Information")]
        public class Personal_Information
        {

            [Key]
            public string Personal_Username { get; set; }
            public string Personal_Password { get; set; }
        }
    
}
