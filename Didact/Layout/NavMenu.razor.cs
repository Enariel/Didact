using Didact.Models;
using Microsoft.AspNetCore.Components;

namespace Didact.Layout;

public partial class NavMenu
{
    private bool collapseNavMenu = true;
    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    [CascadingParameter] public Author Author { get; set; }

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}