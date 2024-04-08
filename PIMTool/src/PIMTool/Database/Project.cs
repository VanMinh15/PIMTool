using System;
using System.Collections.Generic;

namespace PIMTool.Database;

public partial class Project
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int ProjectNumber { get; set; }

    public char Name { get; set; }

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int Version { get; set; }

    public virtual Group Group { get; set; } = null!;
}
