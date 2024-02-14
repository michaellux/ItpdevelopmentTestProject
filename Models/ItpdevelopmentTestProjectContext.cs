using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace ItpdevelopmentTestProject.Models;

public partial class ItpdevelopmentTestProjectContext : DbContext
{
    public ItpdevelopmentTestProjectContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public ItpdevelopmentTestProjectContext(DbContextOptions<ItpdevelopmentTestProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskComment> TaskComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=ItpdevelopmentTestProject;Username=postgres;Password=root;");
        optionsBuilder.EnableSensitiveDataLogging();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CancelDate).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Project");
        });

        modelBuilder.Entity<TaskComment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Task).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskComments_Task");
        });

        FillTestData(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    private static void FillTestData(ModelBuilder modelBuilder)
    {
        Guid projectGuid1 = Guid.NewGuid();
        Guid projectGuid2 = Guid.NewGuid();
        Guid projectGuid3 = Guid.NewGuid();

        Guid taskGuid1 = Guid.NewGuid();
        Guid taskGuid2 = Guid.NewGuid();
        Guid taskGuid3 = Guid.NewGuid();

        Guid taskCommentsGuid1 = Guid.NewGuid();
        Guid taskCommentsGuid2 = Guid.NewGuid();

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = projectGuid1,
                ProjectName = "Solve solution for X",
                CreateDate = new LocalDateTime(2012, 3, 12, 12, 4, 0),
                UpdateDate = new LocalDateTime(2012, 6, 10, 15, 3, 2)
            },
            new Project
            {
                Id = projectGuid2,
                ProjectName = "Buy new tools",
                CreateDate = new LocalDateTime(2012, 5, 12, 20, 34, 26),
                UpdateDate = new LocalDateTime(2012, 6, 10, 12, 44, 25)
            },
            new Project
            {
                Id = projectGuid3,
                ProjectName = "Fix update",
                CreateDate = new LocalDateTime(2012, 9, 12, 20, 34, 26),
                UpdateDate = new LocalDateTime(2012, 10, 10, 2, 41, 23)
            }
        );

        modelBuilder.Entity<Task>().HasData(
            new Task
            {
                Id = taskGuid1,
                TaskName = "Find the reason",
                ProjectId = projectGuid1,
                StartDate = new LocalDateTime(2012, 3, 12, 12, 10, 34),
                CancelDate = new LocalDateTime(2012, 3, 13, 14, 12, 3),
                CreateDate = new LocalDateTime(2012, 3, 12, 12, 10, 12),
                UpdateDate = new LocalDateTime(2012, 3, 13, 14, 12, 3)
            },
            new Task
            {
                Id = taskGuid2,
                TaskName = "Buy IDE",
                ProjectId = projectGuid2,
                StartDate = new LocalDateTime(2020, 5, 7, 4, 34, 34),
                CancelDate = null,
                CreateDate = new LocalDateTime(2020, 5, 7, 2, 3, 23),
                UpdateDate = new LocalDateTime(2020, 5, 7, 4, 34, 34)
            },
            new Task
            {
                Id = taskGuid3,
                TaskName = "Change settings",
                ProjectId = projectGuid3,
                StartDate = new LocalDateTime(2022, 11, 22, 23, 44, 0),
                CancelDate = new LocalDateTime(2022, 11, 23, 13, 0, 45),
                CreateDate = new LocalDateTime(2022, 11, 22, 20, 33, 43),
                UpdateDate = new LocalDateTime(2022, 11, 23, 12, 0, 4)
            }
        );

        modelBuilder.Entity<TaskComment>().HasData(
            new TaskComment
            {
                Id = taskCommentsGuid1,
                TaskId = taskGuid1,
                CommentType = 1,
                Content = Encoding.ASCII.GetBytes("I hope to deal with this quickly")
            },
            new TaskComment
            {
                Id = taskCommentsGuid2,
                TaskId = taskGuid2,
                CommentType = 2,
                Content = System.IO.File.ReadAllBytes("..\\ItpdevelopmentTestProject\\Content\\content.txt")
            }
        );
    }

}
