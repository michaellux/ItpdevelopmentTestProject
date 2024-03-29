﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItpdevelopmentTestProject.Models;

public partial class Project
{
    [BindProperty]
    public Guid Id { get; set; }
    public string ProjectName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
