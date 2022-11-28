using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ItpdevelopmentTestProject.Models;

public partial class Task
{
    public Guid Id { get; set; }

    [Display (Name = "Ticket")]
    public string TaskName { get; set; } = null!;

    [BindProperty]
    public Guid ProjectId { get; set; }

    [Display(Name = "Start")]
    [BindProperty]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }
    [Display(Name = "End")]
    [BindProperty]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    public DateTime? CancelDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<TaskComment> TaskComments { get; } = new List<TaskComment>();
}
