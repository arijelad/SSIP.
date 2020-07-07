using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIP.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    LicenceNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RentalHistoryId = table.Column<int>(nullable: false),
                    LicenceCategoryId = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairDetail = table.Column<string>(nullable: true),
                    RepairDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastService = table.Column<DateTime>(nullable: false),
                    LastBigService = table.Column<DateTime>(nullable: false),
                    YearOfManufacture = table.Column<int>(nullable: false),
                    regExpiration = table.Column<DateTime>(nullable: false),
                    RepairRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_Details_Repairs_RepairRefId",
                        column: x => x.RepairRefId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    LicencePlate = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PassangerNumber = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Odometar = table.Column<double>(nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    Availability = table.Column<bool>(nullable: false),
                    CategoryRefId = table.Column<int>(nullable: false),
                    DetailRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_CategoryRefId",
                        column: x => x.CategoryRefId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Details_DetailRefId",
                        column: x => x.DetailRefId,
                        principalTable: "Details",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    TotalPayment = table.Column<double>(nullable: false),
                    VehicleRefId = table.Column<int>(nullable: false),
                    CustomerRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Vehicles_VehicleRefId",
                        column: x => x.VehicleRefId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_RepairRefId",
                table: "Details",
                column: "RepairRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerRefId",
                table: "Reservations",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VehicleRefId",
                table: "Reservations",
                column: "VehicleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryRefId",
                table: "Vehicles",
                column: "CategoryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DetailRefId",
                table: "Vehicles",
                column: "DetailRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Repairs");
        }
    }
}
