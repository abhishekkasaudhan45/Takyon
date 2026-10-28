using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.About;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public CompanyOverviewViewModel Overview { get; private set; } = null!;

    public void OnGet()
    {
        Overview = _contentProvider.GetCompanyOverview();
    }
}
