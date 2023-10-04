using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApptmentmentScheduler.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class longadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "Description", "Name" },
                values: new object[] { 1L, new DateTime(2023, 8, 22, 16, 59, 33, 107, DateTimeKind.Local).AddTicks(25), "Meet with the Marketing team", "Abu Ghalib" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
