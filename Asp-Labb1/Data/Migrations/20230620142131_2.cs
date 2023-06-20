using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp_Labb1.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    AbsenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartOfAbsence = table.Column<DateTime>(type: "Date", nullable: false),
                    EndOfAbsence = table.Column<DateTime>(type: "Date", nullable: false),
                    ReasonForAbsence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.AbsenceID);
                    table.ForeignKey(
                        name: "FK_Absence_Employee_FK_EmployeeID",
                        column: x => x.FK_EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_FK_EmployeeID",
                table: "Absence",
                column: "FK_EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");
        }
    }
}
