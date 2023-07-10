using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class Service_category_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Category",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServicesAsJson",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1afde171-d6d2-49b8-8350-a43128fb8f7f", 0, "d9bb60fa-79c9-42c9-96f5-c5f26c04afa5", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEDLXHViAfksg66Ot9AGG+1iUjFxWFJXHHUzLuamGRRUEVgY8JAH47uPABaMtDmwEJg==", null, false, "2e08deb4-9657-4045-be52-b21524aa1969", false, "hbence19" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1afde171-d6d2-49b8-8350-a43128fb8f7f");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Services");

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
    }
}
