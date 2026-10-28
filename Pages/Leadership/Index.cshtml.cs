using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.Leadership;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public IReadOnlyList<LeadershipMemberViewModel> LeadershipTeam { get; private set; } = null!;

    public void OnGet()
    {
        LeadershipTeam = _contentProvider.GetLeadershipTeam();
    }
}
