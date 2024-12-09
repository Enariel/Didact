#region Details

//
// -----------------------------------------
// fuchs
// Didact-16
// 12/08/2024

#endregion

using Didact.Flatify.Enums;
using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Didact.Flatify;

public class FlatifyButtonBase : FlatifyBase
{
    protected string Classname => new CssBuilder()
        .AddClass("button")
        .AddClass("outline", Variant == ButtonVariant.Outlined)
        .AddClass("disabled", Disabled)
        .AddClass("active", Active)
        .AddClass("static", Static)
        .AddClass(Class)
        .Build();
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Filled;

    [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;
    [Parameter] public bool Static { get; set; }
    [Parameter] public bool Active { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    protected virtual async Task OnClickHandler(MouseEventArgs ev)
    {
        if (GetDisabledState())
            return;
        await OnClick.InvokeAsync(ev);
    }

    private bool GetDisabledState()
    {
        return Disabled;
    }
}