set cogs=cogs
mkdir sdtl\

echo Validate
%cogs% validate .

echo JSON
%cogs% publish-json . sdtl\json --overwrite

echo GraphQL
%cogs% publish-graphql . sdtl\graphql --overwrite

echo XSD
%cogs% publish-xsd . sdtl\xsd --overwrite --namespace "http://example.org/sdtl" --namespacePrefix sdtl

echo UML
%cogs% publish-uml . sdtl\uml --location graphviz\release\bin --overwrite

echo OWL
%cogs% publish-owl . sdtl\owl --overwrite

REM %cogs% publish-dot . --location sdtl\dot graphviz\release\bin --overwrite --single
REM %cogs% publish-dot . --location sdtl\dot graphviz\release\bin --overwrite --all --inheritance

echo Sphinx
%cogs% publish-sphinx . sdtl\sphinx --location graphviz\release\bin --overwrite

echo C#
%cogs% publish-cs . sdtl\csharp --overwrite

echo Build Sphinx
REM Generate documentation with Sphinx.
cd sdtl\sphinx
CALL make dirhtml
cd \projects\sdtl-cogs

echo Zipping artifacts
7z a -tzip sdtl.zip sdtl\*

