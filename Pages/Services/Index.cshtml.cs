using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.Services;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public IReadOnlyList<SolutionItemViewModel> CoreSolutions { get; private set; } = null!;
    public IReadOnlyList<SolutionItemViewModel> SpecializedSolutions { get; private set; } = null!;

    public void OnGet()
    {
        CoreSolutions = _contentProvider.GetSolutions(coreOnly: true);
        SpecializedSolutions = _contentProvider.GetSolutions(coreOnly: false)
            .Where(s => !s.IsCoreBrochureSolution)
            .ToList();
    }
}
