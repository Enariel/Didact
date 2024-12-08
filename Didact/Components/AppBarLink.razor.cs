using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Didact.Components;

public partial class AppBarLink
{
    [Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;
    [Parameter] public string Href { get; set; }
    [Parameter] public string Icon { get; set; }
    [Parameter] public string Label { get; set; }
}