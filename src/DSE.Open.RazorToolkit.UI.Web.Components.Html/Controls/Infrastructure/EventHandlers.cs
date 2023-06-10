// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls.Infrastructure;

/// <summary>
/// Configures event handlers for <see cref="HtmlDataGrid{TGridItem}"/>.
/// </summary>
[EventHandler("onclosecolumnoptions", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers
{
}
