using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.Projects;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public IReadOnlyList<ProjectCaseStudyViewModel> Projects { get; private set; } = null!;

    public void OnGet()
    {
        Projects = _contentProvider.GetProjects();
    }
}
