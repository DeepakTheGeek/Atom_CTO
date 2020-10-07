using ATOM_CTO_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATOM_CTO_API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<LocationPoint> LocationPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationPoint>()
                .HasKey(c => new { c.Latitude, c.Longitude });

            modelBuilder.Entity<LocationPoint>()
                .Property(c => c.Latitude).HasColumnType("DECIMAL(9,6)");

            modelBuilder.Entity<LocationPoint>()
                .Property(c => c.Longitude).HasColumnType("DECIMAL(9,6)");
        }
    }
}
