mkdir out\

echo Validate
dotnet Cogs.Console.dll validate .

echo JSON
dotnet Cogs.Console.dll publish-json . out\json --overwrite

echo GraphQL
dotnet Cogs.Console.dll publish-graphql . out\graphql --overwrite

echo XSD
dotnet Cogs.Console.dll publish-xsd . out\xsd --overwrite --namespace "http://example.org/sdtl" --namespacePrefix sdtl

echo UML
dotnet Cogs.Console.dll publish-uml . out\uml graphviz\ --overwrite

REM dotnet Cogs.Console.dll publish-dot . out\dot graphviz\ --overwrite --single
REM dotnet Cogs.Console.dll publish-dot . out\dot graphviz\ --overwrite --all --inheritance

echo Sphinx
dotnet Cogs.Console.dll publish-sphinx . out\sphinx graphviz\ --overwrite

echo C#
dotnet Cogs.Console.dll publish-cs . out\csharp --overwrite

echo Build Sphinx
REM Generate documentation with Sphinx.
PUSHD out\sphinx
make dirhtml
POPD

REM TODO Zip the CSharp source code

REM TODO Copy artifacts

ls out
