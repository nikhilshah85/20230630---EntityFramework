using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst_empAPP.Migrations
{
    /// <inheritdoc />
    public partial class setupdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empDetails",
                columns: table => new
                {
                    empNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empSalary = table.Column<double>(type: "float", nullable: false),
                    empCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empIsPermenant = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empDetails", x => x.empNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empDetails");
        }
    }
}
