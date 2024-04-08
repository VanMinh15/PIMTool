using System;
using System.Collections.Generic;

namespace PIMTool.Core.Domain.Entities;

public partial class Group
{
    public int Id { get; set; }

    public int GroupLeader { get; set; }

    public int? Version { get; set; }

    public virtual Employee GroupLeaderNavigation { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
