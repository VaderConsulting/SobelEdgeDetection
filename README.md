# SobelEdgeDetection

SobelEdgeDetection is a VisualCore.Lab VB.NET WinForms lab for Sobel edge detection with GDI, LockBits, and parallel image work. EdgeForm ("Visual Core: Sobel Edge Detection") loads a JPEG or BMP into a before/after split view and runs Detect Edges (GDI `GetPixel`/`SetPixel`), Detect Edges (Direct `LockBits` via `BitmapDirect`), Multi-Serial (Direct), or Multi-Parallel (Direct). `Parallelizer` splits the bitmap into `ImageWorkUnit` rectangles (one strip per processor, or a single strip for serial), and `VisualCore.Utilities.PrecisionTimer` reports throughput in kilopixels per second.

**Source last updated:** 2010-02-15 · **Language:** VB.NET · **Target:** .NET Framework 2.0 (VS 2008, ToolsVersion 3.5) · **Output:** WinForms WinExe

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `VisualCore.Lab.SobelEdgeDetection` | VB.NET | WinForms WinExe | Sobel lab: `EdgeForm`, `BitmapDirect` (24bpp LockBits), `Parallelizer`, `ImageWorkUnit`; sample JPEGs in `Images/` |

## How to open

Open `VisualCore.Lab.SobelEdgeDetection.sln` in Visual Studio 2008 (or later with .NET Framework 2.0 targeting). The project references `..\VisualCore.Utilities\bin\Release\VisualCore.Utilities.dll` (`PrecisionTimer`); that sibling assembly is not in this tree. `Backup/` and `_UpgradeReport_Files/` are the Visual Studio 2008 conversion leftovers from 15 February 2010.

## Requirements

- Visual Studio 2005 to 2008

## Attribution and provenance

- **Original author:** Jeremy Cowles (assembly copyright Copyright © 2008 Jeremy Cowles)
- **Assembly title / product:** VisualCore.Lab.SobelEdgeDetection
- **Root namespace:** VisualCore.Lab.SobelEdgeDetection
- **Form title:** Visual Core: Sobel Edge Detection
- **VisualCore.Utilities:** referenced for `PrecisionTimer` (hint path `..\VisualCore.Utilities\bin\Release\VisualCore.Utilities.dll`; DLL not shipped in this folder)
- Working copy from my Historical Dev folder `SobelEdgeDetection` (VS 2008 upgrade dated 2010-02-15)

This repository does not claim authorship of Jeremy Cowles' VisualCore.Lab sample. See `THIRD_PARTY_NOTICES.md`.

## License

MIT. Copyright (c) 2026 VaderConsulting, for Dave Robinson's working-copy packaging. Original source copyright remains Jeremy Cowles 2008. See `LICENSE` and `THIRD_PARTY_NOTICES.md`.
