// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

/// <summary>
///
/// </summary>
/// <remarks>
/// <see href="https://getbootstrap.com/docs/5.2/components/list-group/#links-and-buttons"/>
/// </remarks>
public class ListGroupButtonItem : HtmlButton
{
    [Parameter]
    public bool IsActive { get; set; }

    [CascadingParameter]
    public required ListGroup ParentList { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(BootstrapClasses.ListGroupItem);
        classBuilder.Add(BootstrapClasses.ListGroupItemAction);
        classBuilder.AddIfValueTrue(IsActive, BootstrapClasses.Active);

        if (IsDisabled)
        {
            classBuilder.Add(BootstrapClasses.Disabled);
        }

        base.BuildClasses(classBuilder);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentList is null)
        {
            throw new InvalidOperationException($"{nameof(ListGroupButtonItem)} must be contained within a {nameof(ListGroup)}");
        }
    }
}
