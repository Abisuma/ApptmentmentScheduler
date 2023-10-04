using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApptmentmentScheduler.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Appointments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 23, 12, 21, 5, 392, DateTimeKind.Local).AddTicks(415), "Meet with the Marketing team", "Abu Ghalib" },
                    { 2L, new DateTime(2023, 8, 23, 12, 21, 5, 392, DateTimeKind.Local).AddTicks(426), "Meeting with CEO Of LexCorp", "john" }
                });
        }
    }
}
