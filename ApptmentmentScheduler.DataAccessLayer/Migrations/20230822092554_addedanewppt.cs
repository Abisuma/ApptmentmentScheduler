using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApptmentmentScheduler.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedanewppt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Appointments",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Appointments");
        }
    }
}
