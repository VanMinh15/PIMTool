namespace PIMTool.Dtos;

public class ProjectDto
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int ProjectNumber { get; set; }
    public string ProjectName { get; set; } = null!;

    public string Customer { get; set; }
    public string Status { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public int Version { get; set; }
}