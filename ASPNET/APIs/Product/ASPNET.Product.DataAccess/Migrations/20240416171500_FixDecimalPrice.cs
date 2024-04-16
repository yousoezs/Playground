using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNET.Product.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixDecimalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(38,2)",
                precision: 38,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)",
                oldPrecision: 38,
                oldScale: 2);
        }
    }
}
