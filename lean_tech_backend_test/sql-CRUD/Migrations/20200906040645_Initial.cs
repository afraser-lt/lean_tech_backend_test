using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sql_CRUD.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Scac = table.Column<string>(nullable: true),
                    Mc = table.Column<long>(nullable: false),
                    Dot = table.Column<long>(nullable: false),
                    Fein = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackaginTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Heigth = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackaginTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: true),
                    OriginCountry = table.Column<string>(nullable: true),
                    OriginState = table.Column<string>(nullable: true),
                    OriginCity = table.Column<string>(nullable: true),
                    DestinationCountry = table.Column<string>(nullable: true),
                    DestinationState = table.Column<string>(nullable: true),
                    DestinationCity = table.Column<string>(nullable: true),
                    PickupDate = table.Column<DateTime>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    CarrierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Po = table.Column<string>(nullable: true),
                    SpecialInstruction = table.Column<string>(nullable: true),
                    ItemsDesciptions = table.Column<string>(nullable: true),
                    PackaginTypeId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    ShipmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bols_PackaginTypes_PackaginTypeId",
                        column: x => x.PackaginTypeId,
                        principalTable: "PackaginTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bols_Receivers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bols_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Packages = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Pallet = table.Column<bool>(nullable: false),
                    Slip = table.Column<bool>(nullable: false),
                    ShippperInfo = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    BolsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Bols_BolsId",
                        column: x => x.BolsId,
                        principalTable: "Bols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bols_PackaginTypeId",
                table: "Bols",
                column: "PackaginTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bols_ReceiverId",
                table: "Bols",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Bols_ShipmentId",
                table: "Bols",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BolsId",
                table: "Orders",
                column: "BolsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CarrierId",
                table: "Shipments",
                column: "CarrierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Bols");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PackaginTypes");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Carriers");
        }
    }
}
