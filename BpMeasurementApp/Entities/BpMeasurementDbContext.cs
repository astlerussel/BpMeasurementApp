using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BpMeasurementApp.Entities
{
    public class BpMeasurementDbContext : DbContext
    {
        public BpMeasurementDbContext(DbContextOptions<BpMeasurementDbContext> options)
        : base(options) { }

        public DbSet<BpMeasurement> Measurements { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Position>().HasData(
            new Position { ID = "S", Name = "Sitting" },
            new Position { ID = "L", Name = "Lying down" },
            new Position { ID = "ST", Name = "Standing" }
        );
            modelBuilder.Entity<BpMeasurement>().HasData(
            new BpMeasurement { Id = 1, Systolic = 120, Diastolic = 80, MeasurementDate = DateTime.Now, PositionID = "S" },
            new BpMeasurement { Id = 2, Systolic = 130, Diastolic = 85, MeasurementDate = DateTime.Now.AddDays(-1), PositionID = "L" },
            new BpMeasurement { Id = 3, Systolic = 120, Diastolic = 70, MeasurementDate = DateTime.Now.AddDays(-2), PositionID = "ST" },
            new BpMeasurement { Id = 4, Systolic = 130, Diastolic = 90, MeasurementDate = DateTime.Now.AddDays(-3), PositionID = "S" },
            new BpMeasurement { Id = 5, Systolic = 140, Diastolic = 80, MeasurementDate = DateTime.Now.AddDays(-4), PositionID = "L" }
        );
        }
    }
}
