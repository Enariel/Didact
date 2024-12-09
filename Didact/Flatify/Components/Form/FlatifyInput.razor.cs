using System.Linq.Expressions;
using Didact.Flatify.Enums;
using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace Didact.Flatify.Components.Form;

public partial class FlatifyInput<T>
{
    [Parameter] public Expression<Func<T>> For { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public string Placeholder { get; set; }
    [Parameter] public string Helptext { get; set; }
    [Parameter] public bool IsSwitch { get; set; } = false;
    [Parameter] public bool Required { get; set; }
    [Parameter] public InputType Type { get; set; }
    [Parameter] public InputMode Mode { get; set; }
    [Parameter] public bool Disabled { get; set; }
    protected string fieldCssClass => EditContext?.FieldCssClass(FieldIdentifier);

    protected string ClassLabel => new CssBuilder("form-label")
        .AddClass(CssClass)
        .Build();

    protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
    {
        result = default;
        validationErrorMessage = null;

        // Check for null or empty input
        if (string.IsNullOrEmpty(value))
        {
            return true;
        }

        // Handle specific type conversions
        try
        {
            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(value, out int intResult))
                {
                    result = (T)(object)intResult;
                    return true;
                }
                else
                {
                    validationErrorMessage = "Invalid integer format.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(DateTime))
            {
                if (DateTime.TryParse(value, out DateTime dateTimeResult))
                {
                    result = (T)(object)dateTimeResult;
                    return true;
                }
                else
                {
                    validationErrorMessage = "Invalid date format.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(double))
            {
                if (double.TryParse(value, out double doubleResult))
                {
                    result = (T)(object)doubleResult;
                    return true;
                }
                else
                {
                    validationErrorMessage = "Invalid number format.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(string))
            {
                // Simple string assignment if type T is string
                result = (T)(object)value;
                return true;
            }
            else
            {
                // Fallback to default conversion
                result = (T)Convert.ChangeType(value, typeof(T));
                return true;
            }
        }
        catch (InvalidCastException ex)
        {
            validationErrorMessage = $"Type conversion error: {ex.Message}";
        }
        catch (FormatException ex)
        {
            validationErrorMessage = $"Format error: {ex.Message}";
        }
        catch (Exception ex)
        {
            validationErrorMessage = $"Unexpected error: {ex.Message}";
        }

        return false;
    }

}