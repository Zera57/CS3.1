using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailSender.Data.Migrations
{
    public partial class SchedulerTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchedulerTaskID",
                table: "Recipients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchedulerTasks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    ServerID = table.Column<int>(nullable: true),
                    SenderID = table.Column<int>(nullable: true),
                    MessageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerTasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_Senders_SenderID",
                        column: x => x.SenderID,
                        principalTable: "Senders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_Servers_ServerID",
                        column: x => x.ServerID,
                        principalTable: "Servers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_SchedulerTaskID",
                table: "Recipients",
                column: "SchedulerTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_MessageID",
                table: "SchedulerTasks",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_SenderID",
                table: "SchedulerTasks",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_ServerID",
                table: "SchedulerTasks",
                column: "ServerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_SchedulerTasks_SchedulerTaskID",
                table: "Recipients",
                column: "SchedulerTaskID",
                principalTable: "SchedulerTasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_SchedulerTasks_SchedulerTaskID",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "SchedulerTasks");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_SchedulerTaskID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "SchedulerTaskID",
                table: "Recipients");
        }
    }
}
