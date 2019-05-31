using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeOnCore.Migrations
{
    public partial class DailyRoutinerenamedtoGoalGoalTypeenumadded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutines_Journals_JournalId",
                table: "DailyRoutines");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutines_AspNetUsers_UserId",
                table: "DailyRoutines");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_DailyRoutines_DailyRoutineId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyRoutines",
                table: "DailyRoutines");

            migrationBuilder.RenameTable(
                name: "DailyRoutines",
                newName: "Goals");

            migrationBuilder.RenameIndex(
                name: "IX_DailyRoutines_UserId",
                table: "Goals",
                newName: "IX_Goals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyRoutines_JournalId",
                table: "Goals",
                newName: "IX_Goals_JournalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Journals_JournalId",
                table: "Goals",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_AspNetUsers_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Goals_DailyRoutineId",
                table: "Posts",
                column: "DailyRoutineId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Journals_JournalId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_AspNetUsers_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Goals_DailyRoutineId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "DailyRoutines");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_UserId",
                table: "DailyRoutines",
                newName: "IX_DailyRoutines_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_JournalId",
                table: "DailyRoutines",
                newName: "IX_DailyRoutines_JournalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyRoutines",
                table: "DailyRoutines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutines_Journals_JournalId",
                table: "DailyRoutines",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutines_AspNetUsers_UserId",
                table: "DailyRoutines",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_DailyRoutines_DailyRoutineId",
                table: "Posts",
                column: "DailyRoutineId",
                principalTable: "DailyRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
