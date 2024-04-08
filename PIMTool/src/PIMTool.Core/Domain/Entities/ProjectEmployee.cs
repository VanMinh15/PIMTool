using System;
using System.Collections.Generic;

namespace PIMTool.Core.Domain.Entities;

public partial class ProjectEmployee
{
    public int ProjectId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
