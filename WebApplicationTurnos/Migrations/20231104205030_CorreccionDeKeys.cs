using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationTurnos.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionDeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Turno",
                newName: "IdTurno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTurno",
                table: "Turno",
                newName: "Id");
        }
    }
}
