namespace ExtensionConfigApi.Models;

public sealed class ExtensionConfigResponse
{
    public string PanelTitle { get; set; } = "SBC Remote Panel";

    public string PanelSubtitle { get; set; } = "Server tarafindan yonetilen menu";

    public List<ExtensionSection> Sections { get; set; } = [];
}

public sealed class ExtensionSection
{
    public string Title { get; set; } = string.Empty;

    public ExtensionAction Action { get; set; } = new();

    public string SubmenuTitle { get; set; } = "Islemler";

    public List<ExtensionButtonAction> Buttons { get; set; } = [];
}

public sealed class ExtensionButtonAction
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");

    public string Label { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ExtensionAction Action { get; set; } = new();
}

public sealed class ExtensionAction
{
    public string Type { get; set; } = "showAlert";

    public string Message { get; set; } = string.Empty;

    public string? Url { get; set; }

    public string Method { get; set; } = "GET";

    public string? FunctionName { get; set; }

    public Dictionary<string, string>? Arguments { get; set; }
}

public sealed class ExtensionRuntimeConfig
{
    public string Html { get; set; } = string.Empty;

    public string Css { get; set; } = string.Empty;

    public string BootstrapCssUrl { get; set; } = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css";

    public List<string> Scripts { get; set; } = [];
}

public sealed class ExtensionRuntimeResponse
{
    public string Html { get; set; } = string.Empty;

    public string Css { get; set; } = string.Empty;

    public string BootstrapCssUrl { get; set; } = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css";

    public string Script { get; set; } = string.Empty;
}
