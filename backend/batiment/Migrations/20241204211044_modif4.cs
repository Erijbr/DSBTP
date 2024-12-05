using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace batiment.Migrations
{
    /// <inheritdoc />
    public partial class modif4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Poste",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poste",
                table: "Users");
        }
    }
}
