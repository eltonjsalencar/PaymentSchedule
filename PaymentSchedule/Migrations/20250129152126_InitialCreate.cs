using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSchedule.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentFlowSummary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFlowSummary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualInterestRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NumberOfMonths = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentFlowSummaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_PaymentFlowSummary_PaymentFlowSummaryId",
                        column: x => x.PaymentFlowSummaryId,
                        principalTable: "PaymentFlowSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_PaymentFlowSummaryId",
                table: "PaymentDetail",
                column: "PaymentFlowSummaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetail");

            migrationBuilder.DropTable(
                name: "Proposta");

            migrationBuilder.DropTable(
                name: "PaymentFlowSummary");
        }
    }
}
