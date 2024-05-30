using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeDataWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees1",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_lang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees1", x => x.emp_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees2",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_dept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees2", x => x.emp_id);
                });

            migrationBuilder.InsertData(
                table: "Employees1",
                columns: new[] { "emp_id", "emp_lang", "emp_name" },
                values: new object[,]
                {
                    { 300, "C#", "Anu" },
                    { 301, "C", "Mohit" },
                    { 302, "Java", "Sona" },
                    { 303, "Java", "Lana" },
                    { 304, "C#", "Lion" },
                    { 305, "Java", "Ramona" }
                });

            migrationBuilder.InsertData(
                table: "Employees2",
                columns: new[] { "emp_id", "emp_dept", "emp_salary" },
                values: new object[,]
                {
                    { 300, "Designing", 23000 },
                    { 301, "Developing", 40000 },
                    { 302, "HR", 50000 },
                    { 303, "Designing", 60000 },
                    { 403, "Production", 50000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees1");

            migrationBuilder.DropTable(
                name: "Employees2");
        }
    }
}
