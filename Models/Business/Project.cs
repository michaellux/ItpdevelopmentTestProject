using NodaTime;

namespace ItpdevelopmentTestProject.Models
{
    public partial class Project
    {
        public string CreateDateTime
        {
            get
            {
                return CreateDate.ToDateTimeUnspecified().ToString("g");
            }
        }
        public string UpdateDateTime
        {
            get
            {
                return UpdateDate.ToDateTimeUnspecified().ToString("g");
            }
        }

        public static async System.Threading.Tasks.Task CreateAsync(ItpdevelopmentTestProjectContext context, string projectName)
        {
            Guid projectGuid = Guid.NewGuid();

            var now = SystemClock.Instance.GetCurrentInstant().InUtc().WithZone(DateTimeZone.Utc).LocalDateTime;

            context.Projects.Add(
                new Project
                {
                    Id = projectGuid,
                    ProjectName = projectName,
                    CreateDate = now,
                    UpdateDate = now
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
