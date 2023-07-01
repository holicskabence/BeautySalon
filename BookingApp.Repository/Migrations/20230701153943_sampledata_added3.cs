using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class sampledata_added3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fc82bc2-e053-468c-82c7-aa3e159dc41c");

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
                values: new object[] { "05339875-f8c7-45b6-8912-b32efb9bcfcf", 0, "afc5f143-e2b5-474d-9025-fccb82757df4", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEDYUfw8oU1qTtcSPW6457SQAbTURV8rVQ6ZLUY9hw6f+rqasXPpWAG4VDsNQwIRxew==", null, false, "381149a1-0869-4768-afdf-383ed3680c53", false, "hbence19" });

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
                keyValue: "05339875-f8c7-45b6-8912-b32efb9bcfcf");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0fc82bc2-e053-468c-82c7-aa3e159dc41c", 0, "430cc168-4d82-4d34-89d3-b28c658f7837", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEEx5p6P0OC9TnwUAUwXVzSGfmc8zrcvnwtmx7pxUwNcRenwCDj/Kr37U2BC+71KaMg==", null, false, "07af8596-0579-4e65-beb4-7213e15bee75", false, "hbence19" });
        }
    }
}
