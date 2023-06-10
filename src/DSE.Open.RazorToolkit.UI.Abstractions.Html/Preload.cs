// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Abstractions.Html;

public enum Preload
{
    /// <summary>
    /// Indicates that the whole video file can be downloaded, even if the user is not expected to use it.
    /// </summary>
    Auto,

    /// <summary>
    /// Indicates that the video should not be preloaded.
    /// </summary>
    None,

    /// <summary>
    /// Indicates that only video metadata (e.g. length) is fetched.
    /// </summary>
    Metadata
}
