# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

> **Keep in sync:** This file, `AGENTS.md`, and `.github/copilot-instructions.md` share the same content.
> When updating any one of them, update the other two to match.

## Build & Test Commands

Tests use Microsoft.Testing.Platform — use `dotnet run`, not `dotnet test`.

```powershell
# Build
dotnet build ./DSE.Open.RazorToolkit.slnx --configuration Debug

# Run all tests
./eng/scripts/test.ps1 -target test -configuration Debug -target_frameworks net10.0

# Run a single test project
dotnet run --project ./test/DSE.Open.RazorToolkit.UI.Web.Components.Html.Tests

# Run a single test by name
dotnet run --project ./test/DSE.Open.RazorToolkit.UI.Web.Components.Html.Tests -- --filter "FullyQualifiedName~MyTestName"

# Pack (Release only, requires prior build)
dotnet pack ./src/<Project>/<Project>.csproj --configuration Release --no-build
```

If `version.props` is missing, run `dotnet build` (Nerdbank.GitVersioning generates it).

## Architecture

Layered Razor/Blazor component library stack — each layer builds on the one below:

```
Core                              ← pure utilities (no UI)
UI.Abstractions                   ← ClassBuilder, StyleBuilder, interfaces (no Blazor dep)
UI.Abstractions.Html              ← HTML constants & enums (no Blazor dep)
UI.Core                           ← ViewComponent (ComponentBase subclass) + FluentValidation
UI.Web.Components                 ← WebComponent + RenderTreeBuilder extensions
UI.Web.Components.Html            ← strongly-typed HTML element components
UI.Web.Components.Html.Bootstrap  ← Bootstrap 5 components (CSS-only, no attribute overrides)
UI.Web.Components.Html.Markdown   ← MarkdownTextBlock (Markdig)
UI.Graphics.Components.Svg        ← SVG primitive components
UI.Charts                         ← chart data models
UI.Charts.Components              ← SVG-rendered chart components
```

### Component Class Hierarchy

```
ComponentBase
  └── ViewComponent                    (UI.Core)
  └── WebComponent                     (UI.Web.Components)
        └── HtmlComponent              ← AdditionalAttributes, CssClass/CssStyle, BuildClasses/BuildStyles
              └── HtmlElement          ← OuterElementName, Id, TabIndex, Hidden; owns BuildRenderTree
                    └── HtmlContentElement  ← adds ChildContent RenderFragment
                          ├── HtmlInline / HtmlBlock / HtmlSpan / HtmlButton / ...
                          └── Bootstrap components extend these
```

`HtmlComponent` is the substantive base class.

### Rendering Pipeline

`HtmlElement.BuildRenderTree` follows a strict sequence — do not reorder:
1. `OpenElement(0, OuterElementName)`
2. `AddMultipleAttributes(1, AdditionalAttributes)` — forwards unmatched attrs
3. `AddAttributes(sequence, builder)` — virtual; typed params
4. `AddBindings(sequence, builder)` — virtual; event callbacks
5. `AddContent(sequence, builder)` — virtual; child content
6. `AddElementReferenceCapture(...)` + `CloseElement()`

When overriding `AddAttributes`/`AddBindings`, always thread and return `sequence` via `++sequence`, and always call `base`.

## Key Conventions

- **CSS**: Use `ClassBuilder`/`StyleBuilder` via `BuildClasses`/`BuildStyles` overrides. Never set CSS strings directly. Always call `base.BuildClasses()`. `ClassBuilder` auto-merges `AdditionalAttributes["class"]`.
- **Bootstrap components**: Only add `[Parameter]`s and override `BuildClasses`. Do not override `AddAttributes` for styling.
- **Tests are `.razor` files** inheriting `TestContext` (bunit). Use `MarkupMatches` for semantic HTML comparison. Add new namespace imports to `_Imports.razor`, not individual test files.
- **Central Package Management**: All versions in root `Directory.Packages.props`. Never put `Version=` in `.csproj` files.
- **Versioning**: Calendar versioning (`YYYY.Sprint`) via Nerdbank.GitVersioning in `version.json`. Do not edit `version.props`.
- **Language**: C# preview, nullable enabled, implicit usings, .NET analyzers at `AllEnabledByDefault`.
- **Solution file**: `DSE.Open.RazorToolkit.slnx` (modern `.slnx` format).
- **NuGet feeds**: nuget.org + GitHub Packages (`dseinternational`). DSE.* packages route to GitHub feed via package source mapping in `NuGet.config`.
