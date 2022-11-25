using System;
using System.ComponentModel.DataAnnotations;

namespace ItpdevelopmentTestProject.Models
{
    public partial class TaskComment
    {
        public object? Description
        {
            get 
            {
                if (CommentType == 1)
                {
                    return System.Text.Encoding.UTF8.GetString(Content);
                }
                else if (CommentType == 2)
                {
                    return $"/Home/DownLoadFile?id={Id}";
                }
                else
                {
                    return null;
                }
            }
        }
            
    }
}
