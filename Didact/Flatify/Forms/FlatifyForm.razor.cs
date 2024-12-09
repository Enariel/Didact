using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Forms;

public partial class FlatifyForm : FlatifyBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    protected string Classname => new CssBuilder()
        .Build();
}