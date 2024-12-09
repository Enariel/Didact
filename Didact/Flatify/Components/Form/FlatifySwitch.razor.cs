#region Details

//
// -----------------------------------------
// fuchs
// Didact-14
// 12/09/2024

#endregion

using System.Linq.Expressions;
using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components.Form;
/// <inheritdoc />
public partial class FlatifySwitch : FlatifyInput<bool>
{
    protected string ToggleCss => new CssBuilder(CssClass)
        .AddClass("toggle-wrapper")
        .Build();

    protected string ClassCheck => new CssBuilder()
        .AddClass("check")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
    {
        // Attempt to parse the string as a boolean
        var b = bool.TryParse(value, out result);
        validationErrorMessage = b ? null : "The field must be a boolean.";
        return b;
    }
}