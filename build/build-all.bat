mkdir out\

REM Validate the model.
dotnet Cogs.Console.dll validate .

REM Build all the COGS outputs.
dotnet Cogs.Console.dll publish-json . out\json --overwrite
dotnet Cogs.Console.dll publish-graphql . out\graphql --overwrite
dotnet Cogs.Console.dll publish-xsd . out\xsd --overwrite --namespace "http://example.org/sdtl" --namespacePrefix sdtl
dotnet Cogs.Console.dll publish-uml . out\uml release\bin --overwrite
REM dotnet Cogs.Console.dll publish-dot . out\dot release\bin --overwrite --single
REM dotnet Cogs.Console.dll publish-dot . out\dot release\bin --overwrite --all --inheritance
dotnet Cogs.Console.dll publish-sphinx . out\sphinx c:\bin\graphviz\bin --overwrite
dotnet Cogs.Console.dll publish-cs . out\csharp --overwrite

REM Generate documentation with Sphinx.
PUSHD out\sphinx
make dirhtml
POPD

REM TODO Zip the CSharp source code

REM TODO Copy artifacts
