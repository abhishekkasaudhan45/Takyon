using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.Contact;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public IReadOnlyList<OfficeContactViewModel> Offices { get; private set; } = null!;
    public IReadOnlyList<SolutionItemViewModel> Solutions { get; private set; } = null!;
    public IReadOnlyList<string> UnresolvedDiscrepancies { get; private set; } = null!;

    public ContactFormViewModel ContactForm { get; set; } = new();

    public void OnGet()
    {
        Offices = _contentProvider.GetOfficeContacts();
        Solutions = _contentProvider.GetSolutions();
        UnresolvedDiscrepancies = _contentProvider.GetUnresolvedDiscrepancies();
    }
}
