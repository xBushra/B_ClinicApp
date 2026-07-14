using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApp.Migrations
{
    /// <inheritdoc />
    public partial class addpatientstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patient_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_IdentityUser_UserId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSpecialities_Patient_PatientId",
                table: "PatientSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_UserId",
                table: "Patients",
                newName: "IX_Patients_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_IdentityUser_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSpecialities_Patients_PatientId",
                table: "PatientSpecialities",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_IdentityUser_UserId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSpecialities_Patients_PatientId",
                table: "PatientSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_UserId",
                table: "Patient",
                newName: "IX_Patient_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patient_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_IdentityUser_UserId",
                table: "Patient",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSpecialities_Patient_PatientId",
                table: "PatientSpecialities",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
