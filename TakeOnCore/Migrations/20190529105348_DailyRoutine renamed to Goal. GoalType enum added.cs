using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeOnCore.Migrations
{
    public partial class DailyRoutinerenamedtoGoalGoalTypeenumadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalType",
                table: "DailyRoutines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalType",
                table: "DailyRoutines");
        }
    }
}
