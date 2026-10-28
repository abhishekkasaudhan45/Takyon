namespace Takyon.Models.ViewModels;

public class OfficeContactViewModel
{
    public string OfficeType { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsAddressVerified { get; set; } = true;
    public string? UnresolvedNote { get; set; }
}
