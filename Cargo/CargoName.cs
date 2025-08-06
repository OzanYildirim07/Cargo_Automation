using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
    [Table("Cargo_Name")]
    public class CargoName
    {
        [Key]
        public int Cargo_Name_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cargo_Name { get; set; }

        [ForeignKey("Cargo_Location_Table")]
        public int Cargo_Location_ID { get; set; }

        [ForeignKey("Cargo_Status_Table")]
        public byte Cargo_Status_ID { get; set; }

        public virtual Cargo_Location_Table Cargo_Location_Table { get; set; }
        public virtual Cargo_Status_Table Cargo_Status_Table { get; set; }

       

        public virtual ICollection<customer> customer { get; set; }

        //public Cargo_Location_Table Cargo_Location_Table1
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public Cargo_Status_Table Cargo_Status_Table1
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}
    }
}
