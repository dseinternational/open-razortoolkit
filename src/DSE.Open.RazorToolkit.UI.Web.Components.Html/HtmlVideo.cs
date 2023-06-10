// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlVideo : HtmlMediaElement
{
    protected override string OuterElementName => HtmlElements.Video;

    /// <summary>
    /// The height of the Video's display area in pixels.
    /// </summary>
    [Parameter]
    public int? Height { get; set; }

    /// <summary>
    /// Indicates that the video is to be played "inline", that is within the element's playback area.
    /// </summary>
    /// <note>
    /// The absence of this attribute does not imply that the video will always be played in fullscreen.
    /// </note>
    [Parameter]
    public bool PlaysInline { get; set; }

    /// <summary>
    /// A URL for an image to be shown while the video is downloading.
    /// If this attribute isn't specified, nothing is displayed until the first frame is available, then the first frame is shown as the poster frame.
    /// </summary>
    [Parameter]
    public string? Poster { get; set; }

    /// <summary>
    /// The width of the video's display area in pixels.
    /// </summary>
    [Parameter]
    public int? Width { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Height, Height);
        builder.AddAttribute(++sequence, HtmlAttributes.PlaysInline, PlaysInline);
        builder.AddAttribute(++sequence, HtmlAttributes.Poster, Poster);
        builder.AddAttribute(++sequence, HtmlAttributes.Width, Width);

        return base.AddAttributes(sequence, builder);
    }
}
