using Didact.Flatify.Enums;
using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components.Container;

public partial class FlatifyContainer : FlatifyBase
{
    protected string Classname => new CssBuilder($"container-{Size.ToString().ToLower()}")
        .Build();
    [Parameter] public ContainerSize Size { get; set; } = ContainerSize.MD;
    [Parameter] public RenderFragment ChildContent { get; set; }
}