namespace ItpdevelopmentTestProject.Models
{
    public partial class Project
    {
        public string CreateDateTime
        {
            get
            {
                return CreateDate.ToString("g");
            }
        }
        public string UpdateDateTime
        {
            get
            {
                return UpdateDate.ToString("g");
            }
        }

        public static async System.Threading.Tasks.Task CreateAsync(ItpdevelopmentTestProjectContext context, string projectName)
        {
            Guid projectGuid = Guid.NewGuid();

            context.Projects.Add(
                new Project
                {
                    Id = projectGuid,
                    ProjectName = projectName,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
