namespace PIMTool.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateOnly BirthDate { get; set; }

        public int Version { get; set; }

        public char Visa { get; set; }
    }
}
