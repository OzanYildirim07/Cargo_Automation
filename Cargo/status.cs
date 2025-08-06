using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
    
        [Table("Cargo_Status_Table")]
        public class Cargo_Status_Table
        {
            [Key]
            public byte Cargo_Status_ID { get; set; }
            public string Cargo_Status_Name { get; set; }
            public virtual ICollection<customer> customer { get; set; }


        }
    
}
