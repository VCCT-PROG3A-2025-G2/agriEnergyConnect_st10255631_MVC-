using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agri_enegry.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContactDetails", "Name" },
                values: new object[] { "matt12@gmail.com, 555-0101", "Matthew Allison" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContactDetails", "Name" },
                values: new object[] { "lukec@jam.org, 555-0202", "Luke Carlous" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "cliveemp123", "Clive" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "southafrica", "Matt" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "suidAfrika", "LukeC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContactDetails", "Name" },
                values: new object[] { "john@sunnyacres.com, 555-0101", "John's Sunny Acres" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContactDetails", "Name" },
                values: new object[] { "jane@greenfields.org, 555-0202", "Jane's Green Fields" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "EmpP@ss123", "employee01" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "FarmP@ss123", "farmerJohn" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "Username" },
                values: new object[] { "FarmP@ss456", "farmerJane" });
        }
    }
}
