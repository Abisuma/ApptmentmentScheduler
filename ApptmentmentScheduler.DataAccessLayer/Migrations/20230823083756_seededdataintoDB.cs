using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApptmentmentScheduler.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class seededdataintoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2023, 8, 23, 9, 37, 56, 45, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "Description", "Name" },
                values: new object[] { 2L, new DateTime(2023, 8, 23, 9, 37, 56, 45, DateTimeKind.Local).AddTicks(9835), "Meeting with CEO Of LexCorp", "john" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2023, 8, 22, 16, 59, 33, 107, DateTimeKind.Local).AddTicks(25));
        }
    }
}
