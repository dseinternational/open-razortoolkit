// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class ModalToggleButton : Button
{
    [Parameter, EditorRequired]
    public required string TargetId { get; set; }

    protected override void OnParametersSet()
    {
        Guard.IsNotNullOrEmpty(TargetId);
        base.OnParametersSet();
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        Guard.IsNotNull(builder);
        Guard.IsNotNullOrWhiteSpace(TargetId);

        builder.AddAttribute(sequence++, BootstrapDataAttributes.Toggle, "modal");

        var targetId = TargetId;

        if (TargetId[0] != '#')
        {
            targetId = '#' + TargetId;
        }

        builder.AddAttribute(++sequence, BootstrapDataAttributes.Target, targetId);

        return base.AddAttributes(sequence, builder);
    }
}
