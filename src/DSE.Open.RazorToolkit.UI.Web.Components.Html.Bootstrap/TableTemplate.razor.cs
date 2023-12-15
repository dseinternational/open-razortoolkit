// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public partial class TableTemplate<TItem>
{
    /// <summary>
    /// enable a hover state on table rows within a &lt;tbody&gt;.
    /// </summary>
    public bool EnableRowHoverIndication { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies whether to display borders on all sides of the table and cells.
    /// </summary>
    public bool ShowBorders { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        // Add these first
        classBuilder.AddIfValueTrue(EnableRowHoverIndication, "table-hover");
        classBuilder.AddIfValueTrue(ShowBorders, "table-bordered");

        base.BuildClasses(classBuilder);
    }
}

