using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Forms;

public partial class FlatifyInput<T> : FlatifyInputBase<T>
{
    private string _internalText;
    [Parameter] public int Lines { get; set; } = 1;
    [Parameter] public int MaxLines { get; set; } = 1;
    [Parameter] public bool AutoGrow { get; set; }
    [Parameter] public bool FullWidth { get; set; }
    [Parameter] public InputType InputType { get; set; } = InputType.Text;
    [Parameter] public RenderFragment ChildContent { get; set; }
    internal InputType GetInputType() => InputType;
    protected string InputTypeString => GetInputType().ToString().ToLower();
    public string Classname => new CssBuilder("input-wrapper")
        .AddClass("is-textarea", (MaxLines > 1 || AutoGrow))
        .AddClass("floating-label").Build();

    public string InputClassname => new CssBuilder()
        .AddClass("invalid", Error)
        .Build();
}

public class FlatifyInputString : FlatifyInput<string>
{
}