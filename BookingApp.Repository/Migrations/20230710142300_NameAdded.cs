using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Repository.Migrations
{
    public partial class NameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1afde171-d6d2-49b8-8350-a43128fb8f7f");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1afde171-d6d2-49b8-8350-a43128fb8f7f", 0, "d9bb60fa-79c9-42c9-96f5-c5f26c04afa5", "benceholicska@gmail.com", true, "Holicska", "Bence", false, null, null, "HBENCE19", "AQAAAAEAACcQAAAAEDLXHViAfksg66Ot9AGG+1iUjFxWFJXHHUzLuamGRRUEVgY8JAH47uPABaMtDmwEJg==", null, false, "2e08deb4-9657-4045-be52-b21524aa1969", false, "hbence19" });
        }
    }
}
