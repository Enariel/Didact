using Didact.Flatify.Enums;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components;

public partial class FlatifyContainer : FlatifyBase
{
    [Parameter] public ContainerSize Size { get; set; } = ContainerSize.MD;
    [Parameter] public RenderFragment ChildContent { get; set; }
}