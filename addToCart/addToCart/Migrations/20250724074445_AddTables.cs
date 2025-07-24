using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace addToCart.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC07B01EA4B3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prodPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prodDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prodImage = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "No Image"),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3214EC0730B9413F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Product__categor__3A81B327",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
