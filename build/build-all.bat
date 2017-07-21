mkdir out\

REM Validate the model.
dotnet run -- validate .

REM Build all the COGS outputs.
dotnet run -- publish-json . out\json --overwrite
dotnet run -- publish-graphql . out\graphql --overwrite
dotnet run -- publish-xsd . out\xsd --overwrite --namespace "http://example.org/sdtl" --namespacePrefix sdtl
dotnet run -- publish-uml . out\uml release\bin --overwrite
REM dotnet run -- publish-dot . out\dot release\bin --overwrite --single
REM dotnet run -- publish-dot . out\dot release\bin --overwrite --all --inheritance
dotnet run -- publish-sphinx . out\sphinx c:\bin\graphviz\bin --overwrite
dotnet run -- publish-cs . out\csharp --overwrite

REM Generate documentation with Sphinx.
PUSHD %sphinxdir%
make dirhtml
POPD

REM TODO Zip the CSharp source code

REM TODO Copy artifacts
