﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
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
                    Mc = table.Column<string>(nullable: true),
                    Dot = table.Column<string>(nullable: true),
                    Fein = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    OriginCountry = table.Column<string>(nullable: true),
                    OriginState = table.Column<string>(nullable: true),
                    OriginCity = table.Column<string>(nullable: true),
                    DestinationCountry = table.Column<string>(nullable: true),
                    DestinationState = table.Column<string>(nullable: true),
                    DestinationCity = table.Column<string>(nullable: true),
                    PickupDate = table.Column<string>(nullable: true),
                    DeliveryDate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
