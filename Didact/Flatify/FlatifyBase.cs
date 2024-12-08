using Microsoft.AspNetCore.Components;

namespace Didact.Flatify;

public class FlatifyBase : ComponentBase
{
    private ILogger _logger;
    [Inject] private ILoggerFactory LoggerFactory { get; set; } = null!;
    protected ILogger Logger => _logger ??= LoggerFactory.CreateLogger(GetType());

    public Dictionary<string, object> AttributeDict { get; set; } = new Dictionary<string, object>();

    public string Style { get; set; }

    public string Class { get; set; }
}