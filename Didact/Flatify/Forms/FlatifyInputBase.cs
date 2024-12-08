using Didact.Flatify.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Didact.Flatify.Forms;

public abstract class ParameterState<T>
{
    /// <summary>
    /// Gets the current value.
    /// </summary>
    public abstract T? Value { get; }

    /// <summary>
    /// Set the parameter's value.
    /// </summary>
    /// <remarks>
    /// Note: you should never set the parameter's property directly from within the component.
    /// Instead, use SetValueAsync on the ParameterState object.
    /// </remarks>
    /// <param name="value">New parameter's value.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public abstract Task SetValueAsync(T value);

    /// <summary>
    /// Defines an implicit conversion of a <see cref="ParameterState{T}"/> object to its underlying value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="parameterState">The <see cref="ParameterState{T}"/> object to convert.</param>
    /// <returns>The underlying value of type <typeparamref name="T"/>.</returns>
    public static implicit operator T?(ParameterState<T> parameterState) => parameterState.Value;
}

public class FlatifyInputBase<T> : FlatifyFormComponent<T, string>
{
    private bool _isDirty;
    protected string InputElementId => _inputIdState.Value;
    private string _userAttributesId = Identifier.Create("flatify");
    private readonly string _componentId = Identifier.Create("flatify");
    private readonly ParameterState<string> _inputIdState;

    public int? Counter { get; set; }
    [Parameter] public int MaxLength { get; set; } = 524288;
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool ReadOnly { get; set; }
    [Parameter] public string HelperText { get; set; }
    [Parameter] public string Placeholder { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public bool AutoFocus { get; set; }
    [Parameter] public virtual InputMode InputMode { get; set; } = InputMode.text;
    [Parameter] public string Text { get; set; }
    [Parameter] public EventCallback<string> TextChanged { get; set; }
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }
    [Parameter] public EventCallback<T> ValueChanged { get; set; }
    [Parameter] public T Value { get => _value; set => _value = value; }
    [CascadingParameter(Name = "ParentDisabled")]
    private bool ParentDisabled { get; set; }
    [CascadingParameter(Name = "ParentReadOnly")]
    private bool ParentReadOnly { get; set; }

    protected override void OnParametersSet()
    {
        if (SubscribeToParentForm)
        {
            base.OnParametersSet();
        }
    }

    protected virtual async Task SetTextAsync(string? text, bool updateValue = true)
    {
        if (Text != text)
        {
            Text = text;

            if (!string.IsNullOrWhiteSpace(Text))
            {
                Touched = true;
            }

            if (updateValue)
            {
                await UpdateValuePropertyAsync(false);
            }

            await TextChanged.InvokeAsync(Text);
        }
    }

    protected virtual async Task SetValueAsync(T value, bool updateText = true, bool force = false)
    {
        if (EqualityComparer<T>.Default.Equals(Value, value) && !force)
        {
            return;
        }

        _isDirty = true;
        Value = value;

        await ValueChanged.InvokeAsync(Value);

        if (updateText)
        {
            await UpdateTextPropertyAsync(false);
        }

        FieldChanged(Value);
    }

    protected virtual Task UpdateValuePropertyAsync(bool updateText)
    {
        return SetValueAsync(Converter.Get(Text), updateText);
    }

    protected virtual Task UpdateTextPropertyAsync(bool updateValue)
    {
        return SetTextAsync(Converter.Set(Value), updateValue);
    }
}