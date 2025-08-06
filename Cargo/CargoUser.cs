using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cargo
{
    [Table("Cargo_User_Table")]
    public class CargoUser
    {
        [Key]
        public int Cargo_User_Name_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cargo_User_Name { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cargo_User_Tel { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cargo_User_Mail { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cargo_User_Adress { get; set; }
        public virtual ICollection<customer> customer { get; set; }

    }
}
