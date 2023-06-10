// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// Renders a form element that cascades an <see cref="EditContext"/> to descendants.
/// </summary>
public class HtmlEditForm : HtmlForm<EditContext>
{
    private readonly Func<Task> _handleSubmitDelegate; // Cache to avoid per-render allocations

    private EditContext? _editContext;
    private bool _hasSetEditContextExplicitly;

    /// <summary>
    /// Constructs an instance of <see cref="EditForm"/>.
    /// </summary>
    public HtmlEditForm()
    {
        _handleSubmitDelegate = HandleSubmitAsync;
    }

    /// <summary>
    /// Supplies the edit context explicitly. If using this parameter, do not
    /// also supply <see cref="Model"/>, since the model value will be taken
    /// from the <see cref="EditContext.Model"/> property.
    /// </summary>
    [Parameter]
    public EditContext? EditContext
    {
        get => _editContext;
        set
        {
            _editContext = value;
            _hasSetEditContextExplicitly = value != null;
        }
    }

    /// <summary>
    /// Specifies the top-level model object for the form. An edit context will
    /// be constructed for this model. If using this parameter, do not also supply
    /// a value for <see cref="EditContext"/>.
    /// </summary>
    [Parameter] public object? Model { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted.
    ///
    /// If using this parameter, you are responsible for triggering any validation
    /// manually, e.g., by calling <see cref="EditContext.Validate"/>.
    /// </summary>
    [Parameter]
    public EventCallback<EditContext> OnSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="EditContext"/> is determined to be valid.
    /// </summary>
    [Parameter]
    public EventCallback<EditContext> OnValidSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="EditContext"/> is determined to be invalid.
    /// </summary>
    [Parameter]
    public EventCallback<EditContext> OnInvalidSubmit { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if (_hasSetEditContextExplicitly && Model != null)
        {
            throw new InvalidOperationException($"{nameof(EditForm)} requires a {nameof(Model)} " +
                $"parameter, or an {nameof(EditContext)} parameter, but not both.");
        }

        if (!_hasSetEditContextExplicitly && Model == null)
        {
            throw new InvalidOperationException($"{nameof(EditForm)} requires either a {nameof(Model)} " +
                                                $"parameter, or an {nameof(EditContext)} parameter, please provide one of these.");
        }

        // If you're using OnSubmit, it becomes your responsibility to trigger validation manually
        // (e.g., so you can display a "pending" state in the UI). In that case you don't want the
        // system to trigger a second validation implicitly, so don't combine it with the simplified
        // OnValidSubmit/OnInvalidSubmit handlers.
        if (OnSubmit.HasDelegate && (OnValidSubmit.HasDelegate || OnInvalidSubmit.HasDelegate))
        {
            throw new InvalidOperationException($"When supplying an {nameof(OnSubmit)} parameter to " +
                $"{nameof(EditForm)}, do not also supply {nameof(OnValidSubmit)} or {nameof(OnInvalidSubmit)}.");
        }

        // Update _editContext if we don't have one yet, or if they are supplying a
        // potentially new EditContext, or if they are supplying a different Model
        if (Model != null && Model != _editContext?.Model)
        {
            _editContext = new EditContext(Model!);
        }
    }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        builder.OpenComponent<CascadingValue<EditContext>>(3);
        builder.AddAttribute(++sequence, "IsFixed", true);
        builder.AddAttribute(++sequence, "Value", _editContext);
        builder.AddAttribute(++sequence, "ChildContent", ChildContent?.Invoke(_editContext));
        builder.CloseComponent();
        return ++sequence;
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        sequence = base.AddAttributes(sequence, builder);
        builder.AddAttribute(++sequence, "onsubmit", _handleSubmitDelegate);
        return ++sequence;
    }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Debug.Assert(_editContext != null);

        // If _editContext changes, tear down and recreate all descendants.
        // This is so we can safely use the IsFixed optimization on CascadingValue,
        // optimizing for the common case where _editContext never changes.

        builder.OpenRegion(_editContext.GetHashCode());
        base.BuildRenderTree(builder);
        builder.CloseRegion();
    }

    private async Task HandleSubmitAsync()
    {
        Debug.Assert(_editContext != null);

        if (OnSubmit.HasDelegate)
        {
            // When using OnSubmit, the developer takes control of the validation lifecycle
            await OnSubmit.InvokeAsync(_editContext).ConfigureAwait(false);
        }
        else
        {
            // Otherwise, the system implicitly runs validation on form submission
            var isValid = _editContext.Validate(); // This will likely become ValidateAsync later

            if (isValid && OnValidSubmit.HasDelegate)
            {
                await OnValidSubmit.InvokeAsync(_editContext).ConfigureAwait(false);
            }

            if (!isValid && OnInvalidSubmit.HasDelegate)
            {
                await OnInvalidSubmit.InvokeAsync(_editContext).ConfigureAwait(false);
            }
        }
    }
}
