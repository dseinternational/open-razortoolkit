// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public abstract class HtmlMediaElement : HtmlElement
{
    /// <summary>
    /// If true, the video automatically begins to play back as soon as it can do so without stopping to finish loading the data.
    /// </summary>
    [Parameter]
    public bool AutoPlay { get; set; }

    /// <summary>
    /// If true, the browser will offer controls to allow the user to control video playback, including volume, seeking, and pause/resume playback. Defaults to true.
    /// </summary>
    [Parameter]
    public bool Controls { get; set; }

    /// <summary>
    /// If true, the browser will automatically seek back to the start upon reaching the end of the video.
    /// </summary>
    [Parameter]
    public bool Loop { get; set; }

    /// <summary>
    /// Indicates the default setting of the audio contained in the video.
    /// If set, the audio will be initially silenced.
    /// Its default value is false, meaning that the audio will be played when the video is played.
    /// </summary>
    [Parameter]
    public bool Muted { get; set; }

    /// <summary>
    /// Provides a hint to the browser about what the author thinks will lead to the best user experience with regards to what content is loaded before the video is played.
    /// </summary>
    /// <note>
    /// The `autoplay` attribute has precedence over `preload`. If `autoplay` is specified, the browser will need to start downloading the video for playback.
    /// <br />
    /// The specification does not force the browser to follow the value of this attribute; it is a mere hint.
    /// </note>
    [Parameter]
    public Preload Preload { get; set; }

    /// <summary>
    /// The URL of the video to embed. This is optional; you may instead use the &lt;source&gt; element within the video block to specify the video to embed.
    /// </summary>
    [Parameter]
    public string? Source { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.AutoPlay, AutoPlay);
        builder.AddAttribute(++sequence, HtmlAttributes.Controls, Controls);
        builder.AddAttribute(++sequence, HtmlAttributes.Loop, Loop);
        builder.AddAttribute(++sequence, HtmlAttributes.Muted, Muted);
        builder.AddAttribute(++sequence, HtmlAttributes.Preload, PreloadAttributeValue());
        builder.AddAttribute(++sequence, HtmlAttributes.Src, Source);

        return base.AddAttributes(sequence, builder);
    }

    private string? PreloadAttributeValue()
    {
        return Preload switch
        {
            Preload.None => "none",
            Preload.Metadata => "metadata",
            _ => null
        };
    }
}
