using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportApp.Migrations
{
    public partial class addValuesToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Companies_CompanyId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Gates_GateId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gates",
                table: "Gates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Passenger");

            migrationBuilder.RenameTable(
                name: "Gates",
                newName: "Gate");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "Flight");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Aircrafts",
                newName: "Aircraft");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_FlightId",
                table: "Passenger",
                newName: "IX_Passenger_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_GateId",
                table: "Flight",
                newName: "IX_Flight_GateId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_CompanyId",
                table: "Flight",
                newName: "IX_Flight_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gate",
                table: "Gate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Company_CompanyId",
                table: "Flight",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Gate_GateId",
                table: "Flight",
                column: "GateId",
                principalTable: "Gate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Flight_FlightId",
                table: "Passenger",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Company_CompanyId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Gate_GateId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Flight_FlightId",
                table: "Passenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gate",
                table: "Gate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft");

            migrationBuilder.RenameTable(
                name: "Passenger",
                newName: "Passengers");

            migrationBuilder.RenameTable(
                name: "Gate",
                newName: "Gates");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "Flights");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Aircraft",
                newName: "Aircrafts");

            migrationBuilder.RenameIndex(
                name: "IX_Passenger_FlightId",
                table: "Passengers",
                newName: "IX_Passengers_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_GateId",
                table: "Flights",
                newName: "IX_Flights_GateId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_CompanyId",
                table: "Flights",
                newName: "IX_Flights_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gates",
                table: "Gates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Companies_CompanyId",
                table: "Flights",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Gates_GateId",
                table: "Flights",
                column: "GateId",
                principalTable: "Gates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
