namespace Takyon.Models.ViewModels;

public class LeadershipMemberViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string RoleCategory { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}
