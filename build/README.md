# Building SDTL outputs

The Windows build requires .NET 10, PowerShell 7, Python, and a COGS 2 tool
with `publish-rdf` support. It checks RDF support before generating outputs.
The GitHub workflows install the latest released COGS tool and the Python
dependencies from `build/requirements.txt`.

From the repository root:

```powershell
python -m pip install -r build/requirements.txt
.\build\build-windows.bat
```

`COGS_PYTHON` selects the Python executable. `SDTL_OUTPUT_ROOT` selects the
output directory, defaulting to `sdtl-outputs` beneath `RUNNER_TEMP` or `TEMP`.
Use a dedicated directory outside the model checkout: publishers replace their
individual output directories with `--overwrite`.

## Graphviz

The build runs `build/install-dependencies.ps1`, which checks `COGS_DOT`, then
`PATH`, then its portable cache for Graphviz 16.1 or newer. If none qualifies,
it downloads the official Graphviz 16.1.0 portable release, verifies SHA-256,
and checks both the version and SVG rendering. The default cache is
`sdtl-tools/graphviz-16.1.0` beneath `RUNNER_TEMP` or the system temporary
directory; `-ToolDirectory` overrides it. Newer installed versions are accepted.

Both workflows export the selected `dot.exe` as `COGS_DOT`. Direct local builds
also select and pass that executable to the publishers. The old Graphviz 2.38
download and checkout-local installation are no longer used.

Run the dependency checks with:

```powershell
pwsh -NoProfile -File build/test-graphviz.ps1
```

## Output inventory

Filenames come from `Settings/Settings.csv` (`Slug,sdtl20`). Both workflows
validate the slug and use `build/get-published-artifacts.ps1` for the shared
downloadable-package inventory.

| Directory | Files for the current slug |
| --- | --- |
| `xsd` | `sdtl20.xsd`, `xml.xsd` |
| `json` | `sdtl20.schema.json`, `sdtl20.meta-schema.json` |
| `rdf` | `sdtl20.ttl`, `sdtl20.ontology.jsonld`, `sdtl20.context.jsonld`, `sdtl20.shacl.ttl`, `sdtl20.shacl12.ttl` |
| `uml` | `sdtl20.xmi` |
| `dctap` | `sdtl20.dctap.csv` |
| `linkml` | `sdtl20.linkml.yml` |
| `graphql` | `sdtl20.graphqls` |
| `csharp` | Generated C# source, including `Types.cs` |
| `sphinx` | Sphinx sources and built documentation in `build/dirhtml` |

The **Production** SHACL profile is `sdtl20.shacl.ttl`. The separate SHACL 1.2
**Preview** profile is `sdtl20.shacl12.ttl`; its engine qualification remains
advisory. Select one profile for validation and do not merge the two files.
The ontology Turtle and ontology JSON-LD describe the same graph. The context
file supplies term mappings for RDF instances.

RDF and LinkML use the namespace settings from the model. XML retains the
`https://rdf-vocabulary.ddialliance.org/sdtl#` namespace and `sdtl` prefix.
LinkML YAML remains available; LinkML-derived OWL, SHACL, and ShEx are no longer
generated. There are no legacy filename aliases.

## Packaging and deployment

The `sdtl-<short SHA>` artifact contains the eleven required files in `xsd`,
`json`, `rdf`, `uml`, and `dctap`. The `sdtl-outputs-<short SHA>` artifact contains
a ZIP of all nine active output directories listed above. Workflows verify
required outputs before packaging and require new package/archive paths.
Old directories such as `owl` are excluded from the archive.

Master CI continues to upload model and SDTH documentation to `/SDTL/dev/model/`
and `/SDTL/dev/SDTH/`. It also uploads all eleven packaged files to
`s3://docs.ddialliance.org/SDTL/dev/output/`, using their basenames and explicit
media types from the shared artifact inventory. All required files are checked
before upload; failures stop deployment before CloudFront invalidation.
Successful deployment invalidates `/SDTL/dev/*`.

The [SDTL 2.0 Development Outputs page](https://docs.ddialliance.org/SDTL/dev/output/)
lists the nine main downloads. The supporting `xml.xsd` and JSON meta-schema are
also uploaded, without separate page links. Individual file uploads preserve
the page's `index.html` and other existing objects. The website repository
maintains and deploys the page separately.

GitHub artifacts remain available. Pull-request CI and local builds do not deploy.

## Validation

Run `cogs validate .` and review diagnostics as well as the exit code. The
current model has eight `COGS-VAL-SUB-003` warnings about subtype-enabled
properties with no additional concrete subtype. DCTAP and GraphQL also report
projection limitations. Keep these diagnostics visible and review new ones;
do not change the model merely to suppress publisher limitations.

For build changes, verify generated filenames, namespaces, package membership,
and failure behavior for missing artifacts. Compile the XSD with its `xml.xsd`
dependency and parse JSON/RDF outputs. Keep generated outputs out of commits.
