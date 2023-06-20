using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp_Labb1.Data.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.AlterColumn<int>(
                name: "AbsenceTypeID",
                table: "Absence",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence",
                column: "AbsenceTypeID",
                principalTable: "AbsenceType",
                principalColumn: "AbsenceTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.AlterColumn<int>(
                name: "AbsenceTypeID",
                table: "Absence",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence",
                column: "AbsenceTypeID",
                principalTable: "AbsenceType",
                principalColumn: "AbsenceTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
