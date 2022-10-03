using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cudataware.WorkflowServer.Persistence.Migrations
{
    public partial class Workflowtables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "WorkflowExecution");

            migrationBuilder.AddColumn<bool>(
                name: "ExecutionCompleted",
                table: "WorkflowExecution",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionCompleted",
                table: "WorkflowExecution");

            migrationBuilder.AddColumn<int>(
                name: "CorrelationId",
                table: "WorkflowExecution",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
