dotnet run -- validate c:\svn\sdtl-cogs\
dotnet run -- publish-json c:\svn\sdtl-cogs\ d:\out\sdtl\json --overwrite
dotnet run -- publish-graphql c:\svn\sdtl-cogs\ d:\out\sdtl\graphql --overwrite
dotnet run -- publish-xsd c:\svn\sdtl-cogs\ d:\out\sdtl\xsd --overwrite --namespace "http://example.org/sdtl" --namespacePrefix sdtl
dotnet run -- publish-uml c:\svn\sdtl-cogs\ d:\out\sdtl\uml c:\bin\graphviz\bin --overwrite
dotnet run -- publish-dot c:\svn\sdtl-cogs\ d:\out\sdtl\dot c:\bin\graphviz\bin --overwrite --single
dotnet run -- publish-dot c:\svn\sdtl-cogs\ d:\out\sdtl\dot c:\bin\graphviz\bin --overwrite --all --inheritance
dotnet run -- publish-sphinx c:\svn\sdtl-cogs\ d:\out\sdtl\sphinx c:\bin\graphviz\bin --overwrite
dotnet run -- publish-cs c:\svn\sdtl-cogs\ d:\out\sdtl\csharp --overwrite

PUSHD %sphinxdir%
make dirhtml
POPD

