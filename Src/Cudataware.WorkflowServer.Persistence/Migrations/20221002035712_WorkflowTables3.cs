using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cudataware.WorkflowServer.Persistence.Migrations
{
    public partial class WorkflowTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowAction_Workflow_WorkflowId",
                table: "WorkflowAction");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecution_Workflow_WorkflowId",
                table: "WorkflowExecution");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowExecution_WorkflowExecutionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.AddColumn<int>(
                name: "WorkflowActionId",
                table: "WorkflowExecutionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "WorkflowAction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_ActionId",
                table: "WorkflowAction",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowAction_Action_ActionId",
                table: "WorkflowAction",
                column: "ActionId",
                principalTable: "Action",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowAction_Workflow_WorkflowId",
                table: "WorkflowAction",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecution_Workflow_WorkflowId",
                table: "WorkflowExecution",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowAction_WorkflowExecutionId",
                table: "WorkflowExecutionDetail",
                column: "WorkflowExecutionId",
                principalTable: "WorkflowAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowExecution_WorkflowExecutionId",
                table: "WorkflowExecutionDetail",
                column: "WorkflowExecutionId",
                principalTable: "WorkflowExecution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowAction_Action_ActionId",
                table: "WorkflowAction");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowAction_Workflow_WorkflowId",
                table: "WorkflowAction");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecution_Workflow_WorkflowId",
                table: "WorkflowExecution");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowAction_WorkflowExecutionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowExecution_WorkflowExecutionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.DropIndex(
                name: "IX_WorkflowAction_ActionId",
                table: "WorkflowAction");

            migrationBuilder.DropColumn(
                name: "WorkflowActionId",
                table: "WorkflowExecutionDetail");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "WorkflowAction");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowAction_Workflow_WorkflowId",
                table: "WorkflowAction",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecution_Workflow_WorkflowId",
                table: "WorkflowExecution",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowExecutionDetail_WorkflowExecution_WorkflowExecutionId",
                table: "WorkflowExecutionDetail",
                column: "WorkflowExecutionId",
                principalTable: "WorkflowExecution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
