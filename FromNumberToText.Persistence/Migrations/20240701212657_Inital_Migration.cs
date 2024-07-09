using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FromNumberToText.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Inital_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    IdNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.IdNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Number");
        }
    }
}
