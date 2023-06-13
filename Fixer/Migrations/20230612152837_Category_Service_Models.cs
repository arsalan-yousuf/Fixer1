using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fixer.Migrations
{
    /// <inheritdoc />
    public partial class Category_Service_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceStockQty = table.Column<int>(type: "int", nullable: false),
                    ServicePrice = table.Column<int>(type: "int", nullable: false),
                    ServiceCategoryID = table.Column<int>(type: "int", nullable: false),
                    ServiceByteImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Service_Category",
                columns: table => new
                {
                    ServiceCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCategoryByteImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Category", x => x.ServiceCategoryID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Service_Category");
        }
    }
}
