using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public CompanyOverviewViewModel Overview { get; private set; } = null!;
    public IReadOnlyList<SolutionItemViewModel> CoreSolutions { get; private set; } = null!;
    public IReadOnlyList<IndustryVerticalViewModel> FeaturedIndustries { get; private set; } = null!;
    public IReadOnlyList<ProjectCaseStudyViewModel> FeaturedProjects { get; private set; } = null!;
    public IReadOnlyList<PartnerLogoViewModel> FeaturedPartners { get; private set; } = null!;

    public void OnGet()
    {
        Overview = _contentProvider.GetCompanyOverview();
        CoreSolutions = _contentProvider.GetSolutions(coreOnly: true);
        FeaturedIndustries = _contentProvider.GetIndustries().Take(6).ToList();
        FeaturedProjects = _contentProvider.GetProjects().Where(p => p.IsFeaturedOnHome).Take(6).ToList();
        FeaturedPartners = _contentProvider.GetPartners().Where(p => p.IsFeatured).Take(12).ToList();
    }
}
