using Didact.Flatify.Enums;
using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components.Container;

public partial class FlatifyContainer : FlatifyBase
{
    protected string Classname => new CssBuilder($"container-{MaxSize.ToString().ToLower()}")
        .Build();
    [Parameter] public ContainerSize MaxSize { get; set; } = ContainerSize.MD;
    [Parameter] public RenderFragment ChildContent { get; set; }
}