using Microsoft.AspNetCore.Mvc.RazorPages;
using Takyon.Content.Interfaces;
using Takyon.Models.ViewModels;

namespace Takyon.Pages.Clients;

public class IndexModel : PageModel
{
    private readonly ITakyonContentProvider _contentProvider;

    public IndexModel(ITakyonContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    public IReadOnlyList<ClientLogoViewModel> Clients { get; private set; } = null!;

    public void OnGet()
    {
        Clients = _contentProvider.GetClients();
    }
}
