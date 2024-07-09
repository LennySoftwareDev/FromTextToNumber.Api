using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FromNumberToText.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserDefault2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Password", "UserName" },
                values: new object[] { 1, "12345", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1);
        }
    }
}
