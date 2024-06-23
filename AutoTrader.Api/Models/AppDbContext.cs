using AutoTrader.Models.CarInfo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoTrader.Api.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<CarDetails> Cars { get; set; }
        public DbSet<Drive> DriveTypes { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<SeatingCapacity> SeatingCapacities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CarDetails>()
            .HasKey(c => c.CarId);

            builder.Entity<Drive>()
                .HasKey(d => d.DriveId);

            builder.Entity<Fuel>()
                .HasKey(f => f.FuelId);

            builder.Entity<Transmission>()
                .HasKey(t => t.TransmissionId);

            builder.Entity<VehicleType>()
                .HasKey(v => v.VehicleTypeId);

            builder.Entity<IdentityRole>().HasData(
              new IdentityRole { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
              new IdentityRole { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" });


            builder.Entity<Drive>().HasData(
                new Drive { DriveId = 1, Name = "RWD" });
            builder.Entity<Drive>().HasData(
               new Drive { DriveId = 2, Name = "4WD" });

            builder.Entity<Fuel>().HasData(
                new Fuel { FuelId = 1, Description = "Petrol" });
            builder.Entity<Fuel>().HasData(
               new Fuel { FuelId = 2, Description = "Hybrid" });
            builder.Entity<Fuel>().HasData(
            new Fuel { FuelId = 3, Description = "Diesel" });

            builder.Entity<Transmission>().HasData(
                new Transmission { TransmissionId = 1, Name = "6 Speed Automatic Transmission" });
            builder.Entity<Transmission>().HasData(
               new Transmission { TransmissionId = 2, Name = "8 Speed Automatic Transmission" });
            builder.Entity<Transmission>().HasData(
              new Transmission { TransmissionId = 3, Name = "Manual Transmission" });

            builder.Entity<VehicleType>().HasData(
             new VehicleType { VehicleTypeId = 1, Name = "Sports" });
            builder.Entity<VehicleType>().HasData(
            new VehicleType { VehicleTypeId = 2, Name = "SUV" });
            builder.Entity<VehicleType>().HasData(
            new VehicleType { VehicleTypeId = 3, Name = "Sedan" });

            builder.Entity<SeatingCapacity>().HasData(
             new SeatingCapacity { SeatingCapacityId = 1, Description = "2" });
            builder.Entity<SeatingCapacity>().HasData(
             new SeatingCapacity { SeatingCapacityId = 2, Description = "5" });
            builder.Entity<SeatingCapacity>().HasData(
             new SeatingCapacity { SeatingCapacityId = 3, Description = "7" });



            ////seed CarDetails Table
            builder.Entity<CarDetails>().HasData(
                new CarDetails
                {
                    CarId = 1,
                    VehicleTypeId = 1,
                    Engine = "4951cc,Naturally Aspirated,V8,DOHC",
                    TransmissionId = 3,
                    ModelName = "Ford Mustang",
                    Price = "7200000.00m",
                    Ownership = "2nd",
                    PeakTorque = "600 Nm @ 1200 RPM",
                    Doors = "2",
                    DriveId = 1,
                    SeatingCapacityId = 1,
                    ManufacturingYear = "2018",
                    FuelId = 1,
                    KmsDone = "7000.00",
                    ExteriorColor = "RED",
                    PaidFeature = "REMUS Exhaust System",
                    Photo = new byte[] { 48, 130, 8, 0 }

                });

            builder.Entity<CarDetails>().HasData(
             new CarDetails
             {
                 CarId = 2,
                 VehicleTypeId = 3,
                 Engine = "2925cc, Turbocharged, In-Line 6-Cyl, DOHC",
                 TransmissionId = 1,
                 ModelName = "MERCEDES BENZ S350D",
                 Price = "7200000.00",
                 Ownership = "1st",
                 PeakTorque = "524 Nm @ 4250 rpm",
                 Doors = "2",
                 DriveId = 1,
                 SeatingCapacityId = 5,
                 ManufacturingYear = "2018",
                 FuelId = 1,
                 KmsDone = "30000.00",
                 ExteriorColor = "White",
                 PaidFeature = "Stock",
                 Photo = new byte[] { 48, 130, 8, 0 }

             });

        }
    }
}
