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
    }
}
