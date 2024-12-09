using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components.Quote;

public partial class FlatifyQuote
{
    protected string Classname => new CssBuilder()
        .AddClass("no-icon", !UseIcon)
        .AddClass(Class)
        .Build();

    [Parameter] public bool UseIcon { get; set; } = true;
    [Parameter] public string Citation { get; set; }
    [Parameter] public string QuoteText { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
}