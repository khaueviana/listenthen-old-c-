using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ListenThen.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    JobTitleId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneToOneMeeeting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ManagerId = table.Column<Guid>(nullable: true),
                    ReceiverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneToOneMeeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneToOneMeeeting_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OneToOneMeeeting_Employee_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OneToOneMeetingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingNote_Employee_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingNote_OneToOneMeeeting_OneToOneMeetingId",
                        column: x => x.OneToOneMeetingId,
                        principalTable: "OneToOneMeeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingPoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OneToOneMeetingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingPoint_Employee_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingPoint_OneToOneMeeeting_OneToOneMeetingId",
                        column: x => x.OneToOneMeetingId,
                        principalTable: "OneToOneMeeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTitleId",
                table: "Employee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingNote_AuthorId",
                table: "MeetingNote",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingNote_OneToOneMeetingId",
                table: "MeetingNote",
                column: "OneToOneMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPoint_AuthorId",
                table: "MeetingPoint",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPoint_OneToOneMeetingId",
                table: "MeetingPoint",
                column: "OneToOneMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_OneToOneMeeeting_ManagerId",
                table: "OneToOneMeeeting",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_OneToOneMeeeting_ReceiverId",
                table: "OneToOneMeeeting",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingNote");

            migrationBuilder.DropTable(
                name: "MeetingPoint");

            migrationBuilder.DropTable(
                name: "OneToOneMeeeting");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "JobTitle");
        }
    }
}
