using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
    
        [Table("Cargo_Location_Table")]
        public class Cargo_Location_Table
        {
            [Key]
            public int Cargo_Location_ID { get; set; }
            public string Cargo_Location_Name { get; set; }
            public virtual ICollection<customer> customer { get; set; }


        }
    
}
