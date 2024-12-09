#region Details
//
// -----------------------------------------
// fuchs
// Didact-43
// 12/09/2024
#endregion

using Microsoft.AspNetCore.Components.Forms;

namespace Didact.Flatify.Forms;

/// <inheritdoc />
public class FlatifyFieldClassValidator : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = editContext.IsValid(fieldIdentifier);
        return isValid ? "valid" : "invalid";
    }
}