using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.Industries;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public IReadOnlyList<IndustryVerticalViewModel> Industries { get; private set; } = null!;

    public void OnGet()
    {
        Industries = _contentProvider.GetIndustries();
    }
}
