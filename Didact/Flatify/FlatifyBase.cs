using System.Diagnostics.CodeAnalysis;
using Didact.Flatify.Enums;
using Didact.Flatify.Utility;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify;

[SuppressMessage("Usage", "BL0007:Component parameters should be auto properties")]
public class FlatifyBase : ComponentBase
{
    private ILogger _logger;
    private string _class;

    protected Dictionary<string, object> AttributeDict { get; set; } = new Dictionary<string, object>();

    [Parameter] public string Style { get; set; }

    [Parameter]
    public string Class
    {
        get => _class;
        set
        {
            var css = new CssBuilder()
                .AddClass(value)
                .AddClass(Helpers.GetStyleType(StyleType!.Value), StyleType.HasValue)
                .AddClass(Helpers.SizeDict[Size!.Value], Size.HasValue)
                .Build();
            _class = css;
        }
    }

    [Parameter] public StyleType? StyleType { get; set; }
    [Parameter] public Size? Size { get; set; }

    [Inject] private ILoggerFactory LoggerFactory { get; set; } = null!;
    protected ILogger Logger => _logger ??= LoggerFactory.CreateLogger(GetType());

    public string GetClassData()
    {
        string classData = new CssBuilder()
            .AddClass(Class)
            .AddClass(Helpers.GetStyleType(StyleType!.Value), StyleType.HasValue)
            .Build();

        return classData ?? Class;
    }
}