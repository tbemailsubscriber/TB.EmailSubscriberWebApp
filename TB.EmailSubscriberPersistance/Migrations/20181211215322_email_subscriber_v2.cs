using Microsoft.EntityFrameworkCore.Migrations;

namespace TB.EmailSubscriber.Persistence.Migrations
{
    public partial class email_subscriber_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueToken",
                table: "Subscriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueToken",
                table: "Subscriptions");
        }
    }
}
