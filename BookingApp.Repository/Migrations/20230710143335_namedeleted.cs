using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class namedeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf1cb4b2-b644-48ea-b581-bb51ebb93191");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e2556c9b-e9a6-4683-8b29-121a225322d2", 0, "fe3beb57-50fa-4eca-8d03-aa99a0febbda", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEEGYT2po0Z+s/MCmLzjnOQL4DBdmjmBI7dIKHvFyCzco09P483JYkwsR8BIu8YyVNg==", null, false, "15e07ce8-e6fd-45a8-bb23-8edcf7fa745c", false, "hbence19" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2556c9b-e9a6-4683-8b29-121a225322d2");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bf1cb4b2-b644-48ea-b581-bb51ebb93191", 0, "9f63b53f-ecd5-42bd-a817-2bc2de5c4dc6", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, null, "HBENCE19", "AQAAAAEAACcQAAAAECyltBrLZMLn9qsJguC/Aa5VarJc3bRNCth5ahXkgDiYUYDY/pELO8fYsCM0qJx8zA==", null, false, "6b296780-5f93-4a7e-9d2a-8171bcfc5e46", false, "hbence19" });
        }
    }
}
