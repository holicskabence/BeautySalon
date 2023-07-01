using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class dbchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "05339875-f8c7-45b6-8912-b32efb9bcfcf");

            migrationBuilder.DropColumn(
                name: "ServicesAsJson",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentId",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29740177-3a93-45e3-8bf6-cee2f096d78f", 0, "c50c36da-8fbc-4698-b3d6-80a3e69debd5", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAECvAcKwkE3Ojl4Kgkc8n6gMpJHSpcxbGp4jx5vHsP9XK19S+EJiZyiIFqEdejqalgw==", null, false, "122517b3-8573-4bf8-b051-6683ed262ef4", false, "hbence19" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppointmentId",
                table: "Services",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Appointments_AppointmentId",
                table: "Services",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Appointments_AppointmentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_AppointmentId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29740177-3a93-45e3-8bf6-cee2f096d78f");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "ServicesAsJson",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "05339875-f8c7-45b6-8912-b32efb9bcfcf", 0, "afc5f143-e2b5-474d-9025-fccb82757df4", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEDYUfw8oU1qTtcSPW6457SQAbTURV8rVQ6ZLUY9hw6f+rqasXPpWAG4VDsNQwIRxew==", null, false, "381149a1-0869-4768-afdf-383ed3680c53", false, "hbence19" });
        }
    }
}
