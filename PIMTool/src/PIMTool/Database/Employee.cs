using System;
using System.Collections.Generic;

namespace PIMTool.Database;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public char? Visa { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int? Version { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
