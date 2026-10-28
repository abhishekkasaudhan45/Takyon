namespace Takyon.Models.ViewModels;

public class PartnerLogoViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string LogoPath { get; set; } = string.Empty;
    public string AltText { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
}
