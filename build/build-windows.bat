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
%cogs% publish-uml . out\uml --location graphviz\release\bin --overwrite

REM %cogs% publish-dot . --location out\dot graphviz\release\bin --overwrite --single
REM %cogs% publish-dot . --location out\dot graphviz\release\bin --overwrite --all --inheritance

echo Sphinx
%cogs% publish-sphinx . out\sphinx --location graphviz\release\bin --overwrite

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

