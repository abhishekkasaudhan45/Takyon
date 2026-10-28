namespace Takyon.Models.ViewModels;

public class CompanyOverviewViewModel
{
    public string CompanyName { get; set; } = "Takyon Networks Limited";
    public string Tagline { get; set; } = "Passion for Integration";
    public int FoundedYear { get; set; } = 2009;
    public string Headquarters { get; set; } = "Lucknow, Uttar Pradesh";
    public string BseStatus { get; set; } = "BSE Listed Company (Listed August 2025)";
    public string CmmiStatus { get; set; } = "CMMI Level 3 Appraised";
    public string GemStatus { get; set; } = "GeM Registered (Direct Government Procurement)";
    
    public string Mission { get; set; } = 
        "To collaborate with esteemed organizations in their digital transformation journey that will create noticeable, long-term, and significant improvements in their operations.";
    
    public string Vision { get; set; } = 
        "To be recognized across the globe as the specialist in our sector of expertise by offering unmatched quality of our products and services.";

    public List<ValueItem> CoreValues { get; set; } = new();
    public List<CompanyMilestone> Milestones { get; set; } = new();
    public List<EmpanelmentItem> Empanelments { get; set; } = new();
    public List<string> OverviewParagraphs { get; set; } = new();
}

public class ValueItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class CompanyMilestone
{
    public string Year { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class EmpanelmentItem
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
