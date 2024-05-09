set cogs=cogs
set szip="C:\Program Files\7-Zip\7z.exe"
mkdir sdtl-outputs\

echo Validate
%cogs% validate .
if %errorlevel% neq 0 exit /b %errorlevel%

echo JSON
%cogs% publish-json . sdtl-outputs\json --overwrite

echo GraphQL
%cogs% publish-graphql . sdtl-outputs\graphql --overwrite

echo XSD
%cogs% publish-xsd . sdtl-outputs\xsd --overwrite --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix sdtl

echo UML
%cogs% publish-uml . sdtl-outputs\uml --location graphviz\release\bin\dot.exe --overwrite

echo OWL
%cogs% publish-owl . sdtl-outputs\owl --overwrite


echo OWL
cogs publish-owl . sdtl-outputs\owl --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix "sdtl" --overwrite

echo LinkML
cogs publish-linkml . sdtl-outputs\linkml --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix "sdtl" --overwrite

echo Build LinkML
PUSHD sdtl-outputs\linkml
CALL gen-owl --metadata-profile rdfs -f ttl linkml.yml > ..\owl\sdtl.owl.ttl
CALL gen-shacl linkml.yml > ..\owl\sdtl.shacl
CALL gen-shex linkml.yml > ..\owl\sdtl.shex
POPD

REM %cogs% publish-dot . --location sdtl\dot graphviz\release\bin\dot.exe --overwrite --single
REM %cogs% publish-dot . --location sdtl\dot graphviz\release\bin\dot.exe --overwrite --all --inheritance

echo Sphinx
%cogs% publish-sphinx . sdtl-outputs\sphinx --location graphviz\release\bin\dot.exe --overwrite

echo C#
%cogs% publish-cs . sdtl-outputs\csharp --overwrite

echo Build Sphinx
REM Generate documentation with Sphinx.
PUSHD sdtl-outputs\sphinx
CALL make dirhtml
POPD
POPD

echo Zipping artifacts
%szip% a -tzip _artifacts\sdtl.zip sdtl-outputs\*

