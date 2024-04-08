using System;
using System.Collections.Generic;

namespace PIMTool.Core.Domain.Entities;

public partial class Project : IEntity
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int ProjectNumber { get; set; }

    public string Name { get; set; }

    public string Customer { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int Version { get; set; }

    public virtual Group Group { get; set; } = null!;
}
