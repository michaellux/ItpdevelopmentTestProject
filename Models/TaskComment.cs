using System;
using System.Collections.Generic;

namespace ItpdevelopmentTestProject.Models;

public partial class TaskComment
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }

    public byte CommentType { get; set; }

    public byte[] Content { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
