// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

/// <summary>
/// An item in a <see cref="ListGroup"/>.
/// </summary>
/// <remarks>
/// <see href="https://getbootstrap.com/docs/5.2/components/list-group/#basic-example"/>
/// </remarks>
public class ListGroupItem : HtmlListItem
{
    [Parameter]
    public bool IsActive { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.ListGroupItem);
        classBuilder.AddIfValueTrue(IsActive, BootstrapClasses.Active);

        if (IsDisabled)
        {
            classBuilder.AddIfValueTrue(IsDisabled, BootstrapClasses.Disabled);
        }

        base.BuildClasses(classBuilder);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentList is null)
        {
            throw new InvalidOperationException(
                $"{nameof(ListGroupItem)} must be contained within a {nameof(ListGroup)}");
        }
    }
}
