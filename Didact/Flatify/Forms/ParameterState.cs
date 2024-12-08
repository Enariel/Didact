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