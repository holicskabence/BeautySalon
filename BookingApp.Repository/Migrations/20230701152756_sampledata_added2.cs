using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class sampledata_added2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579ad03d-d6cb-4065-85e7-8f9e42055765");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0fc82bc2-e053-468c-82c7-aa3e159dc41c", 0, "430cc168-4d82-4d34-89d3-b28c658f7837", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEEx5p6P0OC9TnwUAUwXVzSGfmc8zrcvnwtmx7pxUwNcRenwCDj/Kr37U2BC+71KaMg==", null, false, "07af8596-0579-4e65-beb4-7213e15bee75", false, "hbence19" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fc82bc2-e053-468c-82c7-aa3e159dc41c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "579ad03d-d6cb-4065-85e7-8f9e42055765", 0, "b8f0bac5-ea1e-4e70-a14a-5684f60c82a6", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAENFbaeKOZmxpNMquReF3VGp4Xo+GYQl8+nGQqi0w+W1Ui3bMA4S6JkFJwNZ/3tAOdw==", null, false, "4fb56846-21b3-4ae1-8a92-6bd2d18e31cb", false, "hbence19" });
        }
    }
}
