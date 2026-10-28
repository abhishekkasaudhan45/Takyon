namespace Takyon.Models.ViewModels;

public class IndustryVerticalViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public List<string> FocusAreas { get; set; } = new();
    public int DisplayOrder { get; set; }
}
