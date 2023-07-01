using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class sampledata_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3060ab19-74c7-41af-914d-d5db2241add3", 0, "b75b68c6-9b59-4822-8fab-680a99e349f2", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEA75OtIyxGm/9CPWYoxvYW1QLagpUn1UUUxRVsZUBy/W3eEoHHkaHXG5tgfTEAzd/Q==", null, false, "c3ddcca5-1786-45b8-ab0e-7409013b219e", false, "hbence19" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_OwnerId",
                table: "Appointments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_OwnerId",
                table: "Appointments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_OwnerId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_OwnerId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3060ab19-74c7-41af-914d-d5db2241add3");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
