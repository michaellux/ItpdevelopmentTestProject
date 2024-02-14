﻿// <auto-generated />
using System;
using ItpdevelopmentTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItpdevelopmentTestProject.Migrations
{
    [DbContext(typeof(ItpdevelopmentTestProjectContext))]
    [Migration("20240214061116_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Project", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("be713ba8-43ba-4bc4-bdeb-cc6de8ffb4a6"),
                            CreateDate = new DateTime(2012, 3, 12, 12, 4, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Solve solution for X",
                            UpdateDate = new DateTime(2012, 6, 10, 15, 3, 2, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c17f8143-ecb8-40a2-938e-aadaa2958ecc"),
                            CreateDate = new DateTime(2012, 5, 12, 20, 34, 26, 0, DateTimeKind.Unspecified),
                            ProjectName = "Buy new tools",
                            UpdateDate = new DateTime(2012, 6, 10, 12, 44, 25, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3413d422-2b37-4f92-8c0b-293fea661ef2"),
                            CreateDate = new DateTime(2012, 9, 12, 20, 34, 26, 0, DateTimeKind.Unspecified),
                            ProjectName = "Fix update",
                            UpdateDate = new DateTime(2012, 10, 10, 2, 41, 23, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("99377871-b098-4759-899d-06458ca8eebd"),
                            CancelDate = new DateTime(2012, 3, 13, 14, 12, 3, 0, DateTimeKind.Unspecified),
                            CreateDate = new DateTime(2012, 3, 12, 12, 10, 12, 0, DateTimeKind.Unspecified),
                            ProjectId = new Guid("be713ba8-43ba-4bc4-bdeb-cc6de8ffb4a6"),
                            StartDate = new DateTime(2012, 3, 12, 12, 10, 34, 0, DateTimeKind.Unspecified),
                            TaskName = "Find the reason",
                            UpdateDate = new DateTime(2012, 3, 13, 14, 12, 3, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("20da882b-ee3f-4105-af87-49a786f49c79"),
                            CreateDate = new DateTime(2020, 5, 7, 2, 3, 23, 0, DateTimeKind.Unspecified),
                            ProjectId = new Guid("c17f8143-ecb8-40a2-938e-aadaa2958ecc"),
                            StartDate = new DateTime(2020, 5, 7, 4, 34, 34, 0, DateTimeKind.Unspecified),
                            TaskName = "Buy IDE",
                            UpdateDate = new DateTime(2020, 5, 7, 4, 34, 34, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("5ae96fd6-8f5d-452b-8da5-0f854b1b394c"),
                            CancelDate = new DateTime(2022, 11, 23, 13, 0, 45, 0, DateTimeKind.Unspecified),
                            CreateDate = new DateTime(2022, 11, 22, 20, 33, 43, 0, DateTimeKind.Unspecified),
                            ProjectId = new Guid("3413d422-2b37-4f92-8c0b-293fea661ef2"),
                            StartDate = new DateTime(2022, 11, 22, 23, 44, 0, 0, DateTimeKind.Unspecified),
                            TaskName = "Change settings",
                            UpdateDate = new DateTime(2022, 11, 23, 12, 0, 4, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.TaskComment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<byte>("CommentType")
                        .HasColumnType("smallint");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskComments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2bf9d95-b472-4fbe-bf28-ffc0a7fdea64"),
                            CommentType = (byte)1,
                            Content = new byte[] { 73, 32, 104, 111, 112, 101, 32, 116, 111, 32, 100, 101, 97, 108, 32, 119, 105, 116, 104, 32, 116, 104, 105, 115, 32, 113, 117, 105, 99, 107, 108, 121 },
                            TaskId = new Guid("99377871-b098-4759-899d-06458ca8eebd")
                        },
                        new
                        {
                            Id = new Guid("9d311b4f-5e6a-46e5-94eb-477e1c42387c"),
                            CommentType = (byte)2,
                            Content = new byte[] { 123, 13, 10, 32, 32, 32, 32, 34, 115, 116, 97, 116, 117, 115, 34, 58, 32, 34, 79, 75, 34, 44, 13, 10, 32, 32, 32, 32, 34, 99, 111, 100, 101, 34, 58, 32, 50, 48, 48, 44, 13, 10, 32, 32, 32, 32, 34, 116, 111, 116, 97, 108, 34, 58, 32, 49, 44, 13, 10, 32, 32, 32, 32, 34, 100, 97, 116, 97, 34, 58, 32, 91, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 123, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 105, 100, 34, 58, 32, 49, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 115, 116, 114, 101, 101, 116, 34, 58, 32, 34, 52, 53, 55, 32, 70, 97, 104, 101, 121, 32, 82, 105, 118, 101, 114, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 115, 116, 114, 101, 101, 116, 78, 97, 109, 101, 34, 58, 32, 34, 79, 39, 67, 111, 110, 110, 101, 108, 108, 32, 82, 105, 118, 101, 114, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 98, 117, 105, 108, 100, 105, 110, 103, 78, 117, 109, 98, 101, 114, 34, 58, 32, 34, 54, 55, 54, 48, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 105, 116, 121, 34, 58, 32, 34, 80, 114, 111, 104, 97, 115, 107, 97, 102, 111, 114, 116, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 122, 105, 112, 99, 111, 100, 101, 34, 58, 32, 34, 57, 49, 55, 51, 56, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 111, 117, 110, 116, 114, 121, 34, 58, 32, 34, 83, 97, 110, 32, 77, 97, 114, 105, 110, 111, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 99, 111, 117, 110, 116, 121, 95, 99, 111, 100, 101, 34, 58, 32, 34, 86, 71, 34, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 108, 97, 116, 105, 116, 117, 100, 101, 34, 58, 32, 53, 49, 46, 49, 50, 55, 51, 55, 51, 44, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 34, 108, 111, 110, 103, 105, 116, 117, 100, 101, 34, 58, 32, 49, 52, 50, 46, 56, 57, 56, 55, 49, 57, 13, 10, 32, 32, 32, 32, 32, 32, 32, 32, 125, 13, 10, 32, 32, 32, 32, 93, 13, 10, 125 },
                            TaskId = new Guid("20da882b-ee3f-4105-af87-49a786f49c79")
                        });
                });

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.Task", b =>
                {
                    b.HasOne("ItpdevelopmentTestProject.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_Task_Project");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.TaskComment", b =>
                {
                    b.HasOne("ItpdevelopmentTestProject.Models.Task", "Task")
                        .WithMany("TaskComments")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("FK_TaskComments_Task");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ItpdevelopmentTestProject.Models.Task", b =>
                {
                    b.Navigation("TaskComments");
                });
#pragma warning restore 612, 618
        }
    }
}
