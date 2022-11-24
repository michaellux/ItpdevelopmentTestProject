using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ItpdevelopmentTestProject.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_Task",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "ProjectName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("497968f2-a87d-496a-a340-585426c22f0e"), new DateTime(2012, 9, 12, 20, 34, 26, 0, DateTimeKind.Unspecified), "Fix update", new DateTime(2012, 10, 10, 2, 41, 23, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c8293b6-5c11-4a0c-90c3-8b63f37ae283"), new DateTime(2012, 3, 12, 12, 4, 0, 0, DateTimeKind.Unspecified), "Solve solution for X", new DateTime(2012, 6, 10, 15, 3, 2, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4e3d088-2c4a-4b9c-b91e-915780c5e77d"), new DateTime(2012, 5, 12, 20, 34, 26, 0, DateTimeKind.Unspecified), "Buy new tools", new DateTime(2012, 6, 10, 12, 44, 25, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CancelDate", "CreateDate", "ProjectId", "StartDate", "TaskName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("38c28cff-1b70-4245-a734-9256c913d4cf"), null, new DateTime(2020, 5, 7, 2, 3, 23, 0, DateTimeKind.Unspecified), new Guid("b4e3d088-2c4a-4b9c-b91e-915780c5e77d"), new DateTime(2020, 5, 7, 4, 34, 34, 0, DateTimeKind.Unspecified), "Buy IDE", new DateTime(2020, 5, 7, 4, 34, 34, 0, DateTimeKind.Unspecified) },
                    { new Guid("63e3816b-690b-4758-bdda-d28c15dce010"), new DateTime(2022, 11, 23, 13, 0, 45, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 22, 20, 33, 43, 0, DateTimeKind.Unspecified), new Guid("497968f2-a87d-496a-a340-585426c22f0e"), new DateTime(2022, 11, 22, 23, 44, 0, 0, DateTimeKind.Unspecified), "Change settings", new DateTime(2022, 11, 23, 12, 0, 4, 0, DateTimeKind.Unspecified) },
                    { new Guid("7776452f-214e-43d8-8945-2500ea26d131"), new DateTime(2012, 3, 13, 14, 12, 3, 0, DateTimeKind.Unspecified), new DateTime(2012, 3, 12, 12, 10, 12, 0, DateTimeKind.Unspecified), new Guid("5c8293b6-5c11-4a0c-90c3-8b63f37ae283"), new DateTime(2012, 3, 12, 12, 10, 34, 0, DateTimeKind.Unspecified), "Find the reason", new DateTime(2012, 3, 13, 14, 12, 3, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[,]
                {
                    { new Guid("7197a536-1fdf-44f9-ad62-b50910b83607"), (byte)2, new byte[] { 123, 13, 10, 32, 32, 32, 32, 34, 115, 116, 97, 116, 117, 115, 34, 58, 32, 34, 79, 75, 34, 44, 13, 10, 32, 32, 32, 32, 34, 99, 111, 100, 101, 34, 58, 32, 50, 48, 48, 44, 13, 10, 32, 32, 32, 32, 34, 116, 111, 116, 97, 108, 34, 58, 32, 49, 44, 13, 10, 32, 32, 32, 32, 34, 100, 97, 116, 97, 34, 58, 32, 91, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 123, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 105, 100, 34, 58, 32, 49, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 115, 116, 114, 101, 101, 116, 34, 58, 32, 34, 52, 53, 55, 32, 70, 97, 104, 101, 121, 32, 82, 105, 118, 101, 114, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 115, 116, 114, 101, 101, 116, 78, 97, 109, 101, 34, 58, 32, 34, 79, 39, 67, 111, 110, 110, 101, 108, 108, 32, 82, 105, 118, 101, 114, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 98, 117, 105, 108, 100, 105, 110, 103, 78, 117, 109, 98, 101, 114, 34, 58, 32, 34, 54, 55, 54, 48, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 105, 116, 121, 34, 58, 32, 34, 80, 114, 111, 104, 97, 115, 107, 97, 102, 111, 114, 116, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 122, 105, 112, 99, 111, 100, 101, 34, 58, 32, 34, 57, 49, 55, 51, 56, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 111, 117, 110, 116, 114, 121, 34, 58, 32, 34, 83, 97, 110, 32, 77, 97, 114, 105, 110, 111, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 111, 117, 110, 116, 121, 95, 99, 111, 100, 101, 34, 58, 32, 34, 86, 71, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 108, 97, 116, 105, 116, 117, 100, 101, 34, 58, 32, 53, 49, 46, 49, 50, 55, 51, 55, 51, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 108, 111, 110, 103, 105, 116, 117, 100, 101, 34, 58, 32, 49, 52, 50, 46, 56, 57, 56, 55, 49, 57, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 125, 13, 10, 32, 32, 32, 32, 93, 13, 10, 125 }, new Guid("38c28cff-1b70-4245-a734-9256c913d4cf") },
                    { new Guid("8082f3d2-ed3b-4511-8248-ee84dce7b7b2"), (byte)1, new byte[] { 73, 32, 104, 111, 112, 101, 32, 116, 111, 32, 100, 101, 97, 108, 32, 119, 105, 116, 104, 32, 116, 104, 105, 115, 32, 113, 117, 105, 99, 107, 108, 121 }, new Guid("7776452f-214e-43d8-8945-2500ea26d131") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
