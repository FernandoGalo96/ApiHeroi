using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Denovo.Migrations
{
    /// <inheritdoc />
    public partial class arrumandodenovo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroisBatalhas",
                table: "HeroisBatalhas");

            migrationBuilder.DropIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroisBatalhas",
                table: "HeroisBatalhas",
                columns: new[] { "HeroiId", "BatalhaId" });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_BatalhaId",
                table: "HeroisBatalhas",
                column: "BatalhaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroisBatalhas",
                table: "HeroisBatalhas");

            migrationBuilder.DropIndex(
                name: "IX_HeroisBatalhas_BatalhaId",
                table: "HeroisBatalhas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroisBatalhas",
                table: "HeroisBatalhas",
                columns: new[] { "BatalhaId", "HeroiId" });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas",
                column: "HeroiId");
        }
    }
}
