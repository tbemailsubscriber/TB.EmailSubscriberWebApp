using Microsoft.EntityFrameworkCore.Migrations;

namespace TB.EmailSubscriber.Persistence.Migrations
{
    public partial class email_subscriber_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscriptions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Email",
                table: "Subscriptions",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_Email",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscriptions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
