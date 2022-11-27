using System;
using System.ComponentModel.DataAnnotations;

namespace ItpdevelopmentTestProject.Models
{
    enum CommentTypes
    {
        Text = 1,
        File = 2
    }

    public partial class TaskComment
    {
        public object? Description
        {
            get 
            {
                if (CommentType == (int)CommentTypes.Text)
                {
                    return System.Text.Encoding.UTF8.GetString(Content);
                }
                else if (CommentType == (int)CommentTypes.File)
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
