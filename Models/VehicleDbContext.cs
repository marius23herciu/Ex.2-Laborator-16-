using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex._2_Laborator_16_.Models
{
    class VehicleDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public VehicleDbContext() : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seb\Desktop\fasttrackIT\Projects\Laborator 16\Ex.2(Laborator 16)\Vehicle.mdf;Integrated Security=True;MultipleActiveResultSets=true;");
        }
    }
}
