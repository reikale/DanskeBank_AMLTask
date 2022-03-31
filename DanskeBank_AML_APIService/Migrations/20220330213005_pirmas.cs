using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanskeBank_AML_APIService.Migrations
{
    public partial class pirmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipalities_TaxRules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "TaxRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxes_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Taxes_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaxRules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AddTaxes" },
                    { 2, "ChooseSmallest" }
                });

            migrationBuilder.InsertData(
                table: "TaxType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yearly" },
                    { 2, "Monthly" },
                    { 3, "Weekly" },
                    { 4, "Daily" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_RuleId",
                table: "Municipalities",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_MunicipalityId",
                table: "Taxes",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_TaxTypeId",
                table: "Taxes",
                column: "TaxTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "TaxType");

            migrationBuilder.DropTable(
                name: "TaxRules");
        }
    }
}
