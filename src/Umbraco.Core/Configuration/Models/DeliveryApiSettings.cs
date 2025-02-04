﻿using System.ComponentModel;

namespace Umbraco.Cms.Core.Configuration.Models;

/// <summary>
///     Typed configuration options for Delivery API settings.
/// </summary>
[UmbracoOptions(Constants.Configuration.ConfigDeliveryApi)]
public class DeliveryApiSettings
{
    private const bool StaticEnabled = false;

    private const bool StaticPublicAccess = true;

    private const bool StaticRichTextOutputAsJson = false;

    /// <summary>
    ///     Gets or sets a value indicating whether the Delivery API should be enabled.
    /// </summary>
    /// <value><c>true</c> if the Delivery API should be enabled; otherwise, <c>false</c>.</value>
    [DefaultValue(StaticEnabled)]
    public bool Enabled { get; set; } = StaticEnabled;

    /// <summary>
    ///     Gets or sets a value indicating whether the Delivery API (if enabled) should be
    ///     publicly available or should require an API key for access.
    /// </summary>
    /// <value><c>true</c> if the Delivery API should be publicly available; <c>false</c> if an API key should be required for access.</value>
    [DefaultValue(StaticPublicAccess)]
    public bool PublicAccess { get; set; } = StaticPublicAccess;

    /// <summary>
    ///     Gets or sets the API key used for authorizing API access (if the API is not publicly available) and preview access.
    /// </summary>
    /// <value>A <c>string</c> representing the API key.</value>
    public string? ApiKey { get; set; } = null;

    /// <summary>
    ///     Gets or sets the aliases of the content types that may never be exposed through the Delivery API. Content of these
    ///     types will never be returned from any Delivery API endpoint, nor added to the query index.
    /// </summary>
    /// <value>The content type aliases that are not to be exposed.</value>
    public string[] DisallowedContentTypeAliases { get; set; } = Array.Empty<string>();

    /// <summary>
    ///     Gets or sets a value indicating whether the Delivery API should output rich text values as JSON instead of HTML.
    /// </summary>
    /// <value><c>true</c> if the Delivery API should output rich text values as JSON; <c>false</c> they should be output as HTML (default).</value>
    [DefaultValue(StaticRichTextOutputAsJson)]
    public bool RichTextOutputAsJson { get; set; } = StaticRichTextOutputAsJson;

    /// <summary>
    ///     Gets or sets the settings for the Media APIs of the Delivery API.
    /// </summary>
    public MediaSettings Media { get; set; } = new ();

    /// <summary>
    ///     Typed configuration options for the Media APIs of the Delivery API.
    /// </summary>
    /// <remarks>
    ///     The Delivery API settings (as configured in <see cref="DeliveryApiSettings"/>) supersede these settings in levels of restriction.
    ///     I.e. the Media APIs cannot be enabled, if the Delivery API is disabled.
    /// </remarks>
    public class MediaSettings
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the Media APIs of the Delivery API should be enabled.
        /// </summary>
        /// <value><c>true</c> if the Media APIs should be enabled; otherwise, <c>false</c>.</value>
        /// <remarks>
        ///     Setting this to <c>true</c> will have no effect if the Delivery API itself is disabled through <see cref="DeliveryApiSettings"/>
        /// </remarks>
        [DefaultValue(StaticEnabled)]
        public bool Enabled { get; set; } = StaticEnabled;

        /// <summary>
        ///     Gets or sets a value indicating whether the Media APIs of the Delivery API (if enabled) should be
        ///     publicly available or should require an API key for access.
        /// </summary>
        /// <value><c>true</c> if the Media APIs should be publicly available; <c>false</c> if an API key should be required for access.</value>
        /// <remarks>
        ///     Setting this to <c>true</c> will have no effect if the Delivery API itself has public access disabled through <see cref="DeliveryApiSettings"/>
        /// </remarks>
        [DefaultValue(StaticPublicAccess)]
        public bool PublicAccess { get; set; } = StaticPublicAccess;
    }
}
