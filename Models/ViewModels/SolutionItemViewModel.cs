namespace Takyon.Models.ViewModels;

public class SolutionItemViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // "Core IT Solution" or "Specialized Service"
    public bool IsCoreBrochureSolution { get; set; } = true;
    public string Summary { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public List<string> SubServices { get; set; } = new();
    public List<string> KeyHighlights { get; set; } = new();
    public List<string> WhyItMatters { get; set; } = new();
    public int DisplayOrder { get; set; }
}
