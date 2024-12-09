using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace Didact.Flatify.Components.Form;

public class FlatifyBaseInput<T> : FlatifyBase
{
    [Parameter] public EventCallback<T> ValueChanged { get; set; }
    private T _value;

    [Parameter] public string Id { get; set; }

    [Parameter] public int TabIndex { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public string Helptext { get; set; }
    [Parameter] public string Placeholder { get; set; }
    [Parameter] public bool Required { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public Expression<Func<T>> For { get; set; }
    [Parameter]
    public T Value
    {
        get => _value;
        set => _value = value;
    }
}