using System.ComponentModel.DataAnnotations;

namespace ItpdevelopmentTestProject.Models
{
    public partial class Task
    {
        [Display(Name = "Times")]
        public string SpentTime
        {
            get
            {
                TimeSpan diff = CancelDate - StartDate ?? TimeSpan.Zero;
                return string.Format("{0:hh\\:mm}", diff);
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
            
    }
}
