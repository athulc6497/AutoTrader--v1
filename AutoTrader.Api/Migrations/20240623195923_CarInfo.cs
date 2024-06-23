using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoTrader.Api.Migrations
{
    /// <inheritdoc />
    public partial class CarInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47147e34-cc64-472b-b5b2-5ca42a4c045c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79c966b7-d0f8-4874-a026-37e995799f5b");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    Ownership = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeakTorque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacityId = table.Column<int>(type: "int", nullable: false),
                    ManufacturingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    KmsDone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExteriorColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidFeature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    DriveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.DriveId);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    FuelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.FuelId);
                });

            migrationBuilder.CreateTable(
                name: "SeatingCapacities",
                columns: table => new
                {
                    SeatingCapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatingCapacities", x => x.SeatingCapacityId);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    TransmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.TransmissionId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43a8b4fe-2a66-4c20-8986-7d2880f6c47b", "2", "User", "User" },
                    { "4f4c6a06-8aee-4f7f-961f-ed28a3566d45", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Doors", "DriveId", "Engine", "ExteriorColor", "FuelId", "KmsDone", "ManufacturingYear", "ModelName", "Ownership", "PaidFeature", "PeakTorque", "Photo", "Price", "SeatingCapacityId", "TransmissionId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, "2", 1, "4951cc,Naturally Aspirated,V8,DOHC", "RED", 1, "7000.00", "2018", "Ford Mustang", "2nd", "REMUS Exhaust System", "600 Nm @ 1200 RPM", null, "7200000.00m", 1, 3, 1 },
                    { 2, "2", 1, "2925cc, Turbocharged, In-Line 6-Cyl, DOHC", "White", 1, "30000.00", "2018", "MERCEDES BENZ S350D", "1st", "Stock", "524 Nm @ 4250 rpm", null, "7200000.00", 5, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "DriveTypes",
                columns: new[] { "DriveId", "Name" },
                values: new object[,]
                {
                    { 1, "RWD" },
                    { 2, "4WD" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "FuelId", "Description" },
                values: new object[,]
                {
                    { 1, "Petrol" },
                    { 2, "Hybrid" },
                    { 3, "Diesel" }
                });

            migrationBuilder.InsertData(
                table: "SeatingCapacities",
                columns: new[] { "SeatingCapacityId", "Description" },
                values: new object[,]
                {
                    { 1, "2" },
                    { 2, "5" },
                    { 3, "7" }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "TransmissionId", "Name" },
                values: new object[,]
                {
                    { 1, "6 Speed Automatic Transmission" },
                    { 2, "8 Speed Automatic Transmission" },
                    { 3, "Manual Transmission" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Sports" },
                    { 2, "SUV" },
                    { 3, "Sedan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "SeatingCapacities");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a8b4fe-2a66-4c20-8986-7d2880f6c47b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4c6a06-8aee-4f7f-961f-ed28a3566d45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47147e34-cc64-472b-b5b2-5ca42a4c045c", "1", "Admin", "Admin" },
                    { "79c966b7-d0f8-4874-a026-37e995799f5b", "2", "User", "User" }
                });
        }
    }
}
