using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Didact.Flatify.Forms;

public abstract class FlatifyFormComponent<T, U> : FlatifyBase, IFormComponent, IAsyncDisposable
{
    protected Converter<T, U> _converter;
    protected T _value;
    private FieldIdentifier _fieldIdentifier;
    private EditContext _currentEditContext;
    private Expression<Func<T>> _currentFor;


    public bool Required { get; set; }
    public bool Error { get; set; }
    public bool HasErrors { get; protected set; }
    public bool Touched { get; protected set; }


    protected virtual bool SetConverter(Converter<T,U> value)
    {
        var changed = _converter != value;
        if (changed)
            _converter = value ?? throw new ArgumentNullException(nameof(value)); // converter is mandatory at all times

        return changed;
    }

    [CascadingParameter]
    internal IForm Form { get; set; }

    [CascadingParameter(Name = "SubscribeToParentForm")]
    internal bool SubscribeToParentForm { get; set; } = true;

    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    [Parameter] public Expression<Func<T>> For { get; set; }

    [Parameter] public Converter<T, U> Converter
    {
        get => _converter;
        set => SetConverter(value);
    }


    protected override Task OnInitializedAsync()
    {
        RegisterAsFormComponent();
        return base.OnInitializedAsync();
    }

    protected virtual void RegisterAsFormComponent()
    {
        if (SubscribeToParentForm)
        {
            Form?.Add(this);
        }
    }

    protected virtual T ReadValue() => _value;

    protected virtual Task WriteValueAsync(T value)
    {
        _value = value;

        return Task.CompletedTask;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (For is not null && For != _currentFor)
        {
            // if there is an EditContext, there is no need for internal validation as it will get overwritten by 'OnValidationStateChanged'
            if (EditContext is null)
            {
                // Extract validation attributes
                // Sourced from https://stackoverflow.com/a/43076222/4839162
                // and also https://stackoverflow.com/questions/59407225/getting-a-custom-attribute-from-a-property-using-an-expression
                var expression = (MemberExpression)For.Body;
            }

            _fieldIdentifier = FieldIdentifier.Create(For);
            _currentFor = For;
        }

        if (EditContext is not null && EditContext != _currentEditContext)
        {
            DetachValidationStateChangedListener();
            EditContext.OnValidationStateChanged += OnValidationStateChanged;
            _currentEditContext = EditContext;
        }
    }

    protected void FieldChanged(object newValue)
    {
        if (SubscribeToParentForm)
        {
            Form?.FieldChanged(this, newValue);
        }
    }

    private void DetachValidationStateChangedListener()
    {
        if (_currentEditContext is not null)
        {
            _currentEditContext.OnValidationStateChanged -= OnValidationStateChanged;
        }
    }

    private void OnValidationStateChanged(object sender, ValidationStateChangedEventArgs e)
    {
        Logger.LogInformation($"Validation state changed for {_fieldIdentifier.FieldName}");
    }

    protected virtual ValueTask DisposeAsyncCore() => ValueTask.CompletedTask;

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        try
        {
            Form?.Remove(this);
        }
        catch
        {
            // ignored
        }

        DetachValidationStateChangedListener();
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }
}