# Copilot Instructions

## Build & Test Commands

```powershell
# Restore
dotnet restore ./DSE.Open.RazorToolkit.slnx

# Build
dotnet build ./DSE.Open.RazorToolkit.slnx --configuration Debug

# Run all tests (tests use Microsoft.Testing.Platform — use dotnet run, not dotnet test)
./eng/scripts/test.ps1 -target test -configuration Debug -target_frameworks net10.0

# Run a single test project
dotnet run --project ./test/DSE.Open.RazorToolkit.UI.Web.Components.Html.Tests

# Run a single test by name filter
dotnet run --project ./test/DSE.Open.RazorToolkit.UI.Web.Components.Html.Tests -- --filter "FullyQualifiedName~MyTestName"

# Pack (Release only)
dotnet pack ./src/<Project>/<Project>.csproj --configuration Release --no-build
```

> `version.props` is generated at build time by Nerdbank.GitVersioning. If it is missing locally, run `./eng/scripts/set-version.ps1` or just `dotnet build` (which triggers it via MSBuild).

## Architecture Overview

The library is a layered stack of Razor/Blazor component libraries, each building on the one below:

```
DSE.Open.RazorToolkit.Core                     ← pure utilities (no UI)
DSE.Open.RazorToolkit.UI.Abstractions          ← ClassBuilder, StyleBuilder, interfaces
DSE.Open.RazorToolkit.UI.Abstractions.Html     ← HTML constants & enums (no Blazor dep)
DSE.Open.RazorToolkit.UI.Core                  ← ViewComponent (ComponentBase subclass) + FluentValidation
DSE.Open.RazorToolkit.UI.Web.Components        ← WebComponent + RenderTreeBuilder extensions
DSE.Open.RazorToolkit.UI.Web.Components.Html   ← strongly-typed HTML element components
DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap   ← Bootstrap 5 components
DSE.Open.RazorToolkit.UI.Web.Components.Html.Markdown    ← MarkdownTextBlock (Markdig)
DSE.Open.RazorToolkit.UI.Graphics.Components.Svg         ← SVG primitive components
DSE.Open.RazorToolkit.UI.Charts                          ← chart data models
DSE.Open.RazorToolkit.UI.Charts.Components               ← SVG-rendered chart components
```

### Component Class Hierarchy

```
ComponentBase
  └── ViewComponent                    (UI.Core)
  └── WebComponent                     (UI.Web.Components)
        └── HtmlComponent              ← AdditionalAttributes, CssClass/CssStyle, BuildClasses/BuildStyles hooks
              └── HtmlElement          ← OuterElementName, Id, TabIndex, Hidden, etc.; owns BuildRenderTree
                    └── HtmlContentElement  ← adds ChildContent: RenderFragment
                          ├── HtmlInline / HtmlBlock / HtmlSpan / HtmlButton / ...
                          └── ...Bootstrap components extend these
```

`HtmlComponent` is the substantive base — `ViewComponent` and `WebComponent` are minimal pass-throughs.

## Key Conventions

### Component Rendering Pipeline

`HtmlElement.BuildRenderTree` follows a strict sequence — do not reorder:
1. `builder.OpenElement(0, OuterElementName)`
2. `builder.AddMultipleAttributes(1, AdditionalAttributes)` — forwards unmatched attrs
3. `AddAttributes(sequence, builder)` — virtual; typed params written here
4. `AddBindings(sequence, builder)` — virtual; event callbacks written here
5. `AddContent(sequence, builder)` — virtual; child content
6. `builder.AddElementReferenceCapture(...)` + `builder.CloseElement()`

When overriding `AddAttributes` or `AddBindings`, always thread and return the `sequence` integer:
```csharp
protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
{
    builder.AddAttribute(++sequence, "type", ButtonTypeString);
    builder.AddAttribute(++sequence, "disabled", IsDisabled);
    return base.AddAttributes(++sequence, builder); // always call base
}
```

### CSS Classes & Styles — Use ClassBuilder/StyleBuilder, Not Strings

Never set CSS class/style strings directly. Override `BuildClasses`/`BuildStyles` and use the builders:

```csharp
protected override void BuildClasses(ClassBuilder classBuilder)
{
    classBuilder.Add("my-class");
    classBuilder.AddIfValueTrue(IsActive, "active");
    classBuilder.AddIfValueNotNull(Color, "has-color");
    base.BuildClasses(classBuilder); // always call base
}
```

`ClassBuilder` merges any `class` value from `AdditionalAttributes` automatically before `BuildClasses` is called — do not read `AdditionalAttributes["class"]` manually.

### Bootstrap Components — CSS Only, No Attribute Overrides

Bootstrap components only add `[Parameter]`s and override `BuildClasses`. They do **not** override `AddAttributes` for styling concerns. The `ButtonStyle`, `BootstrapSize`, etc. parameters affect CSS classes exclusively.

### AdditionalAttributes Forwarding

All components that inherit from `HtmlComponent` automatically capture and forward unmatched HTML attributes via:
```csharp
[Parameter(CaptureUnmatchedValues = true)]
public virtual IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
```
Typed `[Parameter]`s win over unmatched attrs when the same attribute name appears in both (typed attrs are written after `AddMultipleAttributes`).

### Tests Are Written as Razor Files

Test projects use bunit. Tests are `.razor` files (not `.cs`), inheriting `TestContext` directly:

```razor
@inherits TestContext

@code {
    [Fact]
    public void MyComponent_ShouldRenderCorrectly()
    {
        var cut = Render(@<MyComponent Prop="value" />);
        cut.MarkupMatches("<div class=\"expected\"></div>");
    }
}
```

Use `MarkupMatches` for semantic HTML comparison. Use `Assert.Contains(...)` / `Assert.Equal(...)` (xUnit) for attribute spot-checks. The assertion library `AwesomeAssertions` is available but not yet adopted in existing tests.

Each test project has an `_Imports.razor` that imports bunit and all relevant component namespaces — add new namespaces there, not in individual test files.

### Central Package Management

All NuGet package versions are declared in `Directory.Packages.props` at the root. **Do not specify `Version=` in individual `.csproj` files.** Add new packages to `Directory.Packages.props` first, then reference them with `<PackageReference Include="..." />` (no version).

### Versioning

Calendar versioning (`YYYY.Sprint`) managed by Nerdbank.GitVersioning. The base version lives in `version.json`. Do not edit `version.props` — it is generated. NuGet packages get 3-part versions (e.g. `2026.3.0`); build numbers appear in `FileVersion` only.
