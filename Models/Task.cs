using Microsoft.AspNetCore.Mvc;
using NodaTime;
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
    public LocalDateTime StartDate { get; set; }
    [Display(Name = "End")]
    [BindProperty]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    public LocalDateTime? CancelDate { get; set; }

    public LocalDateTime CreateDate { get; set; }

    public LocalDateTime UpdateDate { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<TaskComment> TaskComments { get; } = new List<TaskComment>();
}
