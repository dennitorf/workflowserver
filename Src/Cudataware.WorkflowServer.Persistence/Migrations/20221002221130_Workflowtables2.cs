using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cudataware.WorkflowServer.Persistence.Migrations
{
    public partial class Workflowtables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowAction_WorkflowExecutionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowExecutionDetail_WorkflowActionId",
                table: "WorkflowExecutionDetail",
                column: "WorkflowActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowAction_WorkflowActionId",
                table: "WorkflowExecutionDetail",
                column: "WorkflowActionId",
                principalTable: "WorkflowAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowAction_WorkflowActionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.DropIndex(
                name: "IX_WorkflowExecutionDetail_WorkflowActionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowAction_WorkflowExecutionId",
                table: "WorkflowExecutionDetail",
                column: "WorkflowExecutionId",
                principalTable: "WorkflowAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
