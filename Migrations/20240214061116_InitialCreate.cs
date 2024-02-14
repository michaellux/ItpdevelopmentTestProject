using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItpdevelopmentTestProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("63e3816b-690b-4758-bdda-d28c15dce010"));

            migrationBuilder.DeleteData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: new Guid("7197a536-1fdf-44f9-ad62-b50910b83607"));

            migrationBuilder.DeleteData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: new Guid("8082f3d2-ed3b-4511-8248-ee84dce7b7b2"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("497968f2-a87d-496a-a340-585426c22f0e"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("38c28cff-1b70-4245-a734-9256c913d4cf"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("7776452f-214e-43d8-8945-2500ea26d131"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("5c8293b6-5c11-4a0c-90c3-8b63f37ae283"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("b4e3d088-2c4a-4b9c-b91e-915780c5e77d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskId",
                table: "TaskComments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Content",
                table: "TaskComments",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "CommentType",
                table: "TaskComments",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TaskComments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "Task",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Task",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Task",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Project",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "ProjectName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3413d422-2b37-4f92-8c0b-293fea661ef2"), new DateTime(2012, 9, 12, 20, 34, 26, 0, DateTimeKind.Unspecified), "Fix update", new DateTime(2012, 10, 10, 2, 41, 23, 0, DateTimeKind.Unspecified) },
                    { new Guid("be713ba8-43ba-4bc4-bdeb-cc6de8ffb4a6"), new DateTime(2012, 3, 12, 12, 4, 0, 0, DateTimeKind.Unspecified), "Solve solution for X", new DateTime(2012, 6, 10, 15, 3, 2, 0, DateTimeKind.Unspecified) },
                    { new Guid("c17f8143-ecb8-40a2-938e-aadaa2958ecc"), new DateTime(2012, 5, 12, 20, 34, 26, 0, DateTimeKind.Unspecified), "Buy new tools", new DateTime(2012, 6, 10, 12, 44, 25, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CancelDate", "CreateDate", "ProjectId", "StartDate", "TaskName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("20da882b-ee3f-4105-af87-49a786f49c79"), null, new DateTime(2020, 5, 7, 2, 3, 23, 0, DateTimeKind.Unspecified), new Guid("c17f8143-ecb8-40a2-938e-aadaa2958ecc"), new DateTime(2020, 5, 7, 4, 34, 34, 0, DateTimeKind.Unspecified), "Buy IDE", new DateTime(2020, 5, 7, 4, 34, 34, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ae96fd6-8f5d-452b-8da5-0f854b1b394c"), new DateTime(2022, 11, 23, 13, 0, 45, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 22, 20, 33, 43, 0, DateTimeKind.Unspecified), new Guid("3413d422-2b37-4f92-8c0b-293fea661ef2"), new DateTime(2022, 11, 22, 23, 44, 0, 0, DateTimeKind.Unspecified), "Change settings", new DateTime(2022, 11, 23, 12, 0, 4, 0, DateTimeKind.Unspecified) },
                    { new Guid("99377871-b098-4759-899d-06458ca8eebd"), new DateTime(2012, 3, 13, 14, 12, 3, 0, DateTimeKind.Unspecified), new DateTime(2012, 3, 12, 12, 10, 12, 0, DateTimeKind.Unspecified), new Guid("be713ba8-43ba-4bc4-bdeb-cc6de8ffb4a6"), new DateTime(2012, 3, 12, 12, 10, 34, 0, DateTimeKind.Unspecified), "Find the reason", new DateTime(2012, 3, 13, 14, 12, 3, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[,]
                {
                    { new Guid("9d311b4f-5e6a-46e5-94eb-477e1c42387c"), (byte)2, new byte[] { 123, 13, 10, 32, 32, 32, 32, 34, 115, 116, 97, 116, 117, 115, 34, 58, 32, 34, 79, 75, 34, 44, 13, 10, 32, 32, 32, 32, 34, 99, 111, 100, 101, 34, 58, 32, 50, 48, 48, 44, 13, 10, 32, 32, 32, 32, 34, 116, 111, 116, 97, 108, 34, 58, 32, 49, 44, 13, 10, 32, 32, 32, 32, 34, 100, 97, 116, 97, 34, 58, 32, 91, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 123, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 105, 100, 34, 58, 32, 49, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 115, 116, 114, 101, 101, 116, 34, 58, 32, 34, 52, 53, 55, 32, 70, 97, 104, 101, 121, 32, 82, 105, 118, 101, 114, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 115, 116, 114, 101, 101, 116, 78, 97, 109, 101, 34, 58, 32, 34, 79, 39, 67, 111, 110, 110, 101, 108, 108, 32, 82, 105, 118, 101, 114, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 98, 117, 105, 108, 100, 105, 110, 103, 78, 117, 109, 98, 101, 114, 34, 58, 32, 34, 54, 55, 54, 48, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 105, 116, 121, 34, 58, 32, 34, 80, 114, 111, 104, 97, 115, 107, 97, 102, 111, 114, 116, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 122, 105, 112, 99, 111, 100, 101, 34, 58, 32, 34, 57, 49, 55, 51, 56, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 111, 117, 110, 116, 114, 121, 34, 58, 32, 34, 83, 97, 110, 32, 77, 97, 114, 105, 110, 111, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 111, 117, 110, 116, 121, 95, 99, 111, 100, 101, 34, 58, 32, 34, 86, 71, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 108, 97, 116, 105, 116, 117, 100, 101, 34, 58, 32, 53, 49, 46, 49, 50, 55, 51, 55, 51, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 108, 111, 110, 103, 105, 116, 117, 100, 101, 34, 58, 32, 49, 52, 50, 46, 56, 57, 56, 55, 49, 57, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 125, 13, 10, 32, 32, 32, 32, 93, 13, 10, 125 }, new Guid("20da882b-ee3f-4105-af87-49a786f49c79") },
                    { new Guid("c2bf9d95-b472-4fbe-bf28-ffc0a7fdea64"), (byte)1, new byte[] { 73, 32, 104, 111, 112, 101, 32, 116, 111, 32, 100, 101, 97, 108, 32, 119, 105, 116, 104, 32, 116, 104, 105, 115, 32, 113, 117, 105, 99, 107, 108, 121 }, new Guid("99377871-b098-4759-899d-06458ca8eebd") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("5ae96fd6-8f5d-452b-8da5-0f854b1b394c"));

            migrationBuilder.DeleteData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: new Guid("9d311b4f-5e6a-46e5-94eb-477e1c42387c"));

            migrationBuilder.DeleteData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: new Guid("c2bf9d95-b472-4fbe-bf28-ffc0a7fdea64"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("3413d422-2b37-4f92-8c0b-293fea661ef2"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("20da882b-ee3f-4105-af87-49a786f49c79"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("99377871-b098-4759-899d-06458ca8eebd"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("be713ba8-43ba-4bc4-bdeb-cc6de8ffb4a6"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("c17f8143-ecb8-40a2-938e-aadaa2958ecc"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskId",
                table: "TaskComments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Content",
                table: "TaskComments",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<byte>(
                name: "CommentType",
                table: "TaskComments",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TaskComments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "Task",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
        }
    }
}
