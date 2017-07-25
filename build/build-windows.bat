set cogs=dotnet cogs\Cogs.Console.dll
mkdir out\

echo Validate
%cogs% validate .

echo JSON
%cogs% publish-json . out\json --overwrite

echo GraphQL
%cogs% publish-graphql . out\graphql --overwrite

echo XSD
%cogs% publish-xsd . out\xsd --overwrite --namespace "http://example.org/sdtl" --namespacePrefix sdtl

echo UML
%cogs% publish-uml . out\uml graphviz\ --overwrite

REM %cogs% publish-dot . out\dot graphviz\ --overwrite --single
REM %cogs% publish-dot . out\dot graphviz\ --overwrite --all --inheritance

echo Sphinx
%cogs% publish-sphinx . out\sphinx graphviz\ --overwrite

echo C#
%cogs% publish-cs . out\csharp --overwrite

echo Build Sphinx
REM Generate documentation with Sphinx.
PUSHD out\sphinx
make dirhtml
make html
POPD

REM TODO Zip the CSharp source code

REM TODO Copy artifacts

