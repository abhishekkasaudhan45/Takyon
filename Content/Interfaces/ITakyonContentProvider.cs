using Takyon.Models.ViewModels;

namespace Takyon.Content.Interfaces;

public interface ITakyonContentProvider
{
    CompanyOverviewViewModel GetCompanyOverview();
    IReadOnlyList<LeadershipMemberViewModel> GetLeadershipTeam();
    IReadOnlyList<SolutionItemViewModel> GetSolutions(bool coreOnly = false);
    SolutionItemViewModel? GetSolutionById(string id);
    IReadOnlyList<IndustryVerticalViewModel> GetIndustries();
    IReadOnlyList<ProjectCaseStudyViewModel> GetProjects();
    IReadOnlyList<ClientLogoViewModel> GetClients();
    IReadOnlyList<PartnerLogoViewModel> GetPartners();
    IReadOnlyList<OfficeContactViewModel> GetOfficeContacts();
    IReadOnlyList<string> GetUnresolvedDiscrepancies();
}
