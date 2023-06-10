// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components;

public static class RenderTreeBuilderExtensions
{
    public static void CreateCascadingValue<TValue>(this RenderTreeBuilder builder, int seq, int seq0, TValue arg0, int seq1, RenderFragment arg1)
    {
        builder.OpenComponent<CascadingValue<TValue>>(seq);
        builder.AddAttribute(seq0, nameof(CascadingValue<TValue>.Value), arg0);
        builder.AddAttribute(seq1, nameof(CascadingValue<TValue>.ChildContent), arg1);
        builder.CloseComponent();
    }
}
