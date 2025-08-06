using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Cargo
{
    internal class BaglantiCumlem : DbContext
    {
        public BaglantiCumlem() : base("name=BaglantiCumlem")
        {

        }
        public DbSet<customer> customer { get; set; }
        public DbSet<Admin_Information> Admin_Information { get; set; }

        public DbSet<Personal_Information> Personal_Information { get; set; }

        public DbSet<Cargo_Location_Table> Cargo_Locations { get; set; }
        public DbSet<Cargo_Status_Table> Cargo_Statuses { get; set; }
        public DbSet<CargoName> Cargo_Name { get; set; }
        public DbSet<CargoUser> Cargo_User { get; set; }


    }
}
