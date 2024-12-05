using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace batiment.Migrations
{
    /// <inheritdoc />
    public partial class modif2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RendezVous_Users_UserId",
                table: "RendezVous");

            migrationBuilder.DropForeignKey(
                name: "FK_Temoignages_Users_UserId",
                table: "Temoignages");

            migrationBuilder.DropColumn(
                name: "Texte",
                table: "Projets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Temoignages",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Temoignages_UserId",
                table: "Temoignages",
                newName: "IX_Temoignages_userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RendezVous",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_RendezVous_UserId",
                table: "RendezVous",
                newName: "IX_RendezVous_userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Temoignages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Temoignages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdService",
                table: "Temoignages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "affiche",
                table: "Temoignages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "RendezVous",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RendezVous",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "accept",
                table: "RendezVous",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_RendezVous_Users_userId",
                table: "RendezVous",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temoignages_Users_userId",
                table: "Temoignages",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RendezVous_Users_userId",
                table: "RendezVous");

            migrationBuilder.DropForeignKey(
                name: "FK_Temoignages_Users_userId",
                table: "Temoignages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Temoignages");

            migrationBuilder.DropColumn(
                name: "IdService",
                table: "Temoignages");

            migrationBuilder.DropColumn(
                name: "affiche",
                table: "Temoignages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RendezVous");

            migrationBuilder.DropColumn(
                name: "accept",
                table: "RendezVous");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Temoignages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Temoignages_userId",
                table: "Temoignages",
                newName: "IX_Temoignages_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "RendezVous",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RendezVous_userId",
                table: "RendezVous",
                newName: "IX_RendezVous_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Temoignages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RendezVous",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Texte",
                table: "Projets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_RendezVous_Users_UserId",
                table: "RendezVous",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temoignages_Users_UserId",
                table: "Temoignages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
