using Microsoft.EntityFrameworkCore;
using NodaTime;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItpdevelopmentTestProject.Models
{
    public partial class Task
    {
        [Display(Name = "Times")]
        public string SpentTime
        {
            get
            {
                Instant now = SystemClock.Instance.GetCurrentInstant();
                ZonedDateTime startZonedDateTime = StartDate.InUtc();
                ZonedDateTime cancelZonedDateTime = CancelDate?.InUtc() ?? now.InUtc();
                Duration diff = cancelZonedDateTime.ToInstant() - startZonedDateTime.ToInstant();
                return $"{diff.Hours:00}:{diff.Minutes:00}";
            }
        }

        public Duration Period
        {
            get
            {
                Instant now = SystemClock.Instance.GetCurrentInstant();
                ZonedDateTime startZonedDateTime = StartDate.InUtc();
                ZonedDateTime cancelZonedDateTime = CancelDate?.InUtc() ?? now.InUtc();
                Duration diff = cancelZonedDateTime.ToInstant() - startZonedDateTime.ToInstant();
                return diff;
            }
        }

        public string StartTime
        {
            get
            {
                return string.Format("{0:hh\\:mm}", StartDate);
            }
        }

        public string EndTime
        {
            get
            {
                return string.Format("{0:hh\\:mm}", CancelDate);
            }
        }

        public static async System.Threading.Tasks.Task Create(ItpdevelopmentTestProjectContext context, string Name, string Project, LocalDateTime StartDate,
            LocalDateTime? CancelDate, string[]? TextContent, List<byte[]>? FileContent)
        {
            Guid taskGuid = Guid.NewGuid();

            var now = SystemClock.Instance.GetCurrentInstant().InUtc().WithZone(DateTimeZone.Utc).LocalDateTime;

            context.Tasks.Add(
                new Task
                {
                    Id = taskGuid,
                    TaskName = Name,
                    ProjectId = new Guid(Project),
                    StartDate = StartDate.InUtc().LocalDateTime,
                    CancelDate = CancelDate?.InUtc().LocalDateTime,
                    CreateDate = now,
                    UpdateDate = now
                }
            );

            if (TextContent != null)
            {
                foreach (var item in TextContent)
                {
                    context.TaskComments.Add(
                        new TaskComment
                        {
                            Id = Guid.NewGuid(),
                            TaskId = taskGuid,
                            CommentType = (int)CommentTypes.Text,
                            Content = Encoding.ASCII.GetBytes(item)
                        }
                    );
                }
            }

            if (FileContent != null)
            {
                foreach (var item in FileContent)
                {
                    context.TaskComments.Add(
                        new TaskComment
                        {
                            Id = Guid.NewGuid(),
                            TaskId = taskGuid,
                            CommentType = (int)CommentTypes.File,
                            Content = item
                        }
                    );
                }
            }

            await context.SaveChangesAsync();
        }


        public static async System.Threading.Tasks.Task Update(ItpdevelopmentTestProjectContext context, Guid id, string Name, string Project, LocalDateTime StartDate,
            LocalDateTime? CancelDate, string[]? TextContent, List<byte[]>? FileContent)
        {
            using (context)
            {
                Task? task = context.Tasks.FirstOrDefault(task => task.Id == id);

                if (task != null)
                {
                    task.TaskName = Name;
                    task.ProjectId = new Guid(Project);
                    task.StartDate = StartDate;
                    task.CancelDate = CancelDate;
                    task.UpdateDate = LocalDateTime.FromDateTime(DateTime.UtcNow);
                }

                if (TextContent != null)
                {
                    foreach (var item in TextContent)
                    {
                        context.TaskComments.Add(
                            new TaskComment
                            {
                                Id = Guid.NewGuid(),
                                TaskId = task.Id,
                                CommentType = (int)CommentTypes.Text,
                                Content = Encoding.ASCII.GetBytes(item)
                            }
                        );
                    }
                }

                if (FileContent != null)
                {
                    foreach (var item in FileContent)
                    {
                        context.TaskComments.Add(
                            new TaskComment
                            {
                                Id = Guid.NewGuid(),
                                TaskId = task.Id,
                                CommentType = (int)CommentTypes.File,
                                Content = item
                            }
                        );
                    }
                }

                context.SaveChanges();
            }
        }

        public static async System.Threading.Tasks.Task RemoveContent(ItpdevelopmentTestProjectContext context, string id)
        {
            TaskComment taskComment = context.TaskComments.FirstOrDefault(taskComment => taskComment.Id == new Guid(id));

            context.TaskComments.Remove(taskComment);

            context.SaveChanges();
        }
        
        public static async System.Threading.Tasks.Task SaveContent(ItpdevelopmentTestProjectContext context, string id, string value)
        {
            TaskComment taskComment = context.TaskComments.FirstOrDefault(taskComment => taskComment.Id == new Guid(id));

            taskComment.Content = Encoding.ASCII.GetBytes(value);

            context.SaveChanges();
        }
    }
}
