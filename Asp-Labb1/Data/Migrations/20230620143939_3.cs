using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp_Labb1.Data.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonForAbsence",
                table: "Absence");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartOfAbsence",
                table: "Absence",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndOfAbsence",
                table: "Absence",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "AbsenceTypeID",
                table: "Absence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_AbsenceTypeID",
                table: "Absence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AbsenceType",
                columns: table => new
                {
                    AbsenceTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfAbsence = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceType", x => x.AbsenceTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_AbsenceTypeID",
                table: "Absence",
                column: "AbsenceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence",
                column: "AbsenceTypeID",
                principalTable: "AbsenceType",
                principalColumn: "AbsenceTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.DropTable(
                name: "AbsenceType");

            migrationBuilder.DropIndex(
                name: "IX_Absence_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "AbsenceTypeID",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "FK_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartOfAbsence",
                table: "Absence",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndOfAbsence",
                table: "Absence",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ReasonForAbsence",
                table: "Absence",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
