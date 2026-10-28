namespace Takyon.Models.ViewModels;

public class ProjectCaseStudyViewModel
{
    public string Id { get; set; } = string.Empty;
    public string ProjectNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Client { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Scope { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public bool IsFeaturedOnHome { get; set; }
    public int DisplayOrder { get; set; }
}
