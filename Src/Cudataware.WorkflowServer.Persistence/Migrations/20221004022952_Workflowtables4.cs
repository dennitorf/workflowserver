using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cudataware.WorkflowServer.Persistence.Migrations
{
    public partial class Workflowtables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionMetadata",
                table: "WorkflowAction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextSecondAction",
                table: "WorkflowAction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionMetadata",
                table: "WorkflowAction");

            migrationBuilder.DropColumn(
                name: "NextSecondAction",
                table: "WorkflowAction");
        }
    }
}
