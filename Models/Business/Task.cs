using Microsoft.EntityFrameworkCore;
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
                TimeSpan diff = (CancelDate == null ? DateTime.UtcNow : CancelDate) - StartDate ?? TimeSpan.Zero;
                return string.Format("{0:hh\\:mm}", diff);
            }
        }

        public TimeSpan Period
        {
            get
            {
                TimeSpan diff = (CancelDate == null ? DateTime.UtcNow : CancelDate) - StartDate ?? TimeSpan.Zero;
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

        public static async System.Threading.Tasks.Task Create(ItpdevelopmentTestProjectContext context, string Name, string Project, DateTime StartDate,
            DateTime? CancelDate, string[]? TextContent, List<byte[]>? FileContent)
        {
            Guid taskGuid = Guid.NewGuid();

            context.Tasks.Add(
                new Task
                {
                    Id = taskGuid,
                    TaskName = Name,
                    ProjectId = new Guid(Project),
                    StartDate = StartDate,
                    CancelDate = CancelDate,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
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


        internal static async System.Threading.Tasks.Task Update(ItpdevelopmentTestProjectContext context, Guid id, string Name, string Project, DateTime StartDate,
            DateTime? CancelDate, string[]? TextContent, List<byte[]>? FileContent)
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
                    task.UpdateDate = DateTime.UtcNow;
                }

                context.SaveChanges();
            }
        }

    }
}
