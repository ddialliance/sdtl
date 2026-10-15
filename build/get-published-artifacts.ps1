[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [ValidatePattern('\A[a-z][a-z0-9_]*\z', Options = 'None')]
    [string]$Slug
)

# Shared inventory for the downloadable package in both GitHub workflows.
$artifacts = @(
    @{ Directory = 'xsd'; Suffix = '.xsd' }
    @{ Directory = 'xsd'; FileName = 'xml.xsd' }
    @{ Directory = 'json'; Suffix = '.schema.json' }
    @{ Directory = 'json'; Suffix = '.meta-schema.json' }
    @{ Directory = 'rdf'; Suffix = '.ttl' }
    @{ Directory = 'rdf'; Suffix = '.ontology.jsonld' }
    @{ Directory = 'rdf'; Suffix = '.context.jsonld' }
    @{ Directory = 'rdf'; Suffix = '.shacl.ttl' }
    @{ Directory = 'rdf'; Suffix = '.shacl12.ttl' }
    @{ Directory = 'uml'; Suffix = '.xmi' }
    @{ Directory = 'dctap'; Suffix = '.dctap.csv' }
)
foreach ($artifact in $artifacts) {
    [pscustomobject]@{
        Directory = $artifact.Directory
        FileName = if ($artifact.ContainsKey('FileName')) {
            $artifact.FileName
        } else {
            $Slug + $artifact.Suffix
        }
    }
}
