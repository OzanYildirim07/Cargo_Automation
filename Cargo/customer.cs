using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Cargo
{

    [Table("Admin_Table")]
    public class customer
    {

        [Key]
        public int Cargo_ID { get; set; }

        [ForeignKey("CargoUser")]
        public int Cargo_User_Name_ID { get; set; }

        [ForeignKey("CargoName")]
        public int Cargo_Name_ID { get; set; }

        [ForeignKey("Cargo_Location")]  
        [Column("Cargo_Location_ID")]
        public int Cargo_Location_ID { get; set; }

        [ForeignKey("Cargo_Status")]    
        [Column("Cargo_Status_ID")]
        public byte Cargo_Status_ID { get; set; }

        [Required]
        public DateTime Cargo_Date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Cargo_Delivery_Date { get; set; }

        public virtual CargoUser CargoUser { get; set; }
        public virtual CargoName CargoName { get; set; }
        public virtual Cargo_Location_Table Cargo_Location { get; set; }
        public virtual Cargo_Status_Table Cargo_Status { get; set; }

        //public CargoName CargoName1
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public CargoUser CargoUser1
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}
    }
}
