// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Abstractions.Html;

public static class MimeTypeExtensions
{
    public static string? ToTypeString(this MimeType mimeType)
    {
        return mimeType switch
        {
            MimeType.None => null,
            MimeType.APNG => "image/apng",
            MimeType.AVIF => "image/avif",
            MimeType.GIF => "image/gif",
            MimeType.JPEG => "image/jpeg",
            MimeType.PNG => "image/png",
            MimeType.SVG => "image/svg+xml",
            MimeType.WebP => "image/webp",
            MimeType.Mpeg => "audio/mpeg",
            MimeType.Ogg => "video/ogg",
            MimeType.Mp4 => "video/mp4",
            MimeType.QuickTime => "video/quicktime",
            MimeType.WebM => "video/webm",
            _ => throw new ArgumentOutOfRangeException(nameof(mimeType), mimeType, null)
        };
    }
}
