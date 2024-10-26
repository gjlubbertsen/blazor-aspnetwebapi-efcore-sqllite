using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contoso.Pizza.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Toppings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "date()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Sauces",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "date()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "PizzaToppings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "date()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Pizzas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "date()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Toppings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "date()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Sauces",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "date()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "PizzaToppings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "date()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Pizzas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "date()");
        }
    }
}
