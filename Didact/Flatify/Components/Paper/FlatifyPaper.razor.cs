using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components.Paper;

public partial class FlatifyPaper : FlatifyBase
{
    protected string Classname => new CssBuilder("card")
        .AddClass(Class)
        .AddClass("mx-4")
        .Build();

    protected string Stylename => new StyleBuilder()
        .AddStyle("height", $"{Height}", !string.IsNullOrEmpty(Height))
        .AddStyle("width", $"{Width}", !string.IsNullOrEmpty(Width))
        .AddStyle("max-height", $"{MaxHeight}", !string.IsNullOrEmpty(MaxHeight))
        .AddStyle("max-width", $"{MaxWidth}", !string.IsNullOrEmpty(MaxWidth))
        .AddStyle("min-height", $"{MinHeight}", !string.IsNullOrEmpty(MinHeight))
        .AddStyle("min-width", $"{MinWidth}", !string.IsNullOrEmpty(MinWidth))
        .AddStyle(Style)
        .Build();

    [Parameter] public string Height { get; set; }
    [Parameter] public string Width { get; set; }
    [Parameter] public string MaxHeight { get; set; }
    [Parameter] public string MaxWidth { get; set; }
    [Parameter] public string MinHeight { get; set; }
    [Parameter] public string MinWidth { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
}