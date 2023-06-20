using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp_Labb1.Data.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.DropIndex(
                name: "IX_Absence_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "AbsenceTypeID",
                table: "Absence");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_FK_AbsenceTypeID",
                table: "Absence",
                column: "FK_AbsenceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AbsenceType_FK_AbsenceTypeID",
                table: "Absence",
                column: "FK_AbsenceTypeID",
                principalTable: "AbsenceType",
                principalColumn: "AbsenceTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AbsenceType_FK_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.DropIndex(
                name: "IX_Absence_FK_AbsenceTypeID",
                table: "Absence");

            migrationBuilder.AddColumn<int>(
                name: "AbsenceTypeID",
                table: "Absence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Absence_AbsenceTypeID",
                table: "Absence",
                column: "AbsenceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AbsenceType_AbsenceTypeID",
                table: "Absence",
                column: "AbsenceTypeID",
                principalTable: "AbsenceType",
                principalColumn: "AbsenceTypeID");
        }
    }
}
