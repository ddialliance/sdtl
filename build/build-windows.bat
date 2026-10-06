@echo off
setlocal EnableExtensions DisableDelayedExpansion

REM Resolve the model independently of the caller's working directory.
for %%I in ("%~dp0..") do set "MODEL_ROOT=%%~fI"

REM COGS 2 publication targets must be outside the model source directory.
REM SDTL_OUTPUT_ROOT can override the default for local builds.
if not defined SDTL_OUTPUT_ROOT if defined RUNNER_TEMP set "SDTL_OUTPUT_ROOT=%RUNNER_TEMP%\sdtl-outputs"
if not defined SDTL_OUTPUT_ROOT set "SDTL_OUTPUT_ROOT=%TEMP%\sdtl-outputs"
for %%I in ("%SDTL_OUTPUT_ROOT%") do set "SDTL_OUTPUT_ROOT=%%~fI"
if not defined COGS_PYTHON set "COGS_PYTHON=python"
if not defined COGS_DOT if exist "%MODEL_ROOT%\graphviz\release\bin\dot.exe" set "COGS_DOT=%MODEL_ROOT%\graphviz\release\bin\dot.exe"
if not defined COGS_DOT if exist "%MODEL_ROOT%\build\graphviz\release\bin\dot.exe" set "COGS_DOT=%MODEL_ROOT%\build\graphviz\release\bin\dot.exe"
set "DOT_OPTION="
if defined COGS_DOT set DOT_OPTION=--dot "%COGS_DOT%"

pushd "%MODEL_ROOT%" || exit /b 1
echo Build outputs: %SDTL_OUTPUT_ROOT%

echo Validate
call :run cogs validate "%MODEL_ROOT%" || goto :fail

echo JSON
call :run cogs publish-json "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\json" --overwrite || goto :fail

echo GraphQL
call :run cogs publish-graphql "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\graphql" --overwrite || goto :fail

echo XSD
call :run cogs publish-xsd "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\xsd" --overwrite --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix sdtl || goto :fail

echo UML
call :run cogs publish-uml "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\uml" --mode ea %DOT_OPTION% --overwrite || goto :fail

echo OWL
call :run cogs publish-owl "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\owl" --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix sdtl --overwrite || goto :fail

echo LinkML
call :run cogs publish-linkml "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\linkml" --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix sdtl --overwrite || goto :fail

echo Build LinkML
REM Keep the LinkML-derived ontology separate from COGS's authoritative sdtl.ttl.
call :run gen-owl --metadata-profile rdfs -f ttl "%SDTL_OUTPUT_ROOT%\linkml\linkml.yml" > "%SDTL_OUTPUT_ROOT%\owl\sdtl.owl.ttl" || goto :fail
call :run gen-shacl "%SDTL_OUTPUT_ROOT%\linkml\linkml.yml" > "%SDTL_OUTPUT_ROOT%\owl\sdtl.shacl" || goto :fail
call :run gen-shex "%SDTL_OUTPUT_ROOT%\linkml\linkml.yml" > "%SDTL_OUTPUT_ROOT%\owl\sdtl.shex" || goto :fail

echo Sphinx
call :run cogs publish-sphinx "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\sphinx" %DOT_OPTION% --overwrite || goto :fail

echo C#
call :run cogs publish-cs "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\csharp" --overwrite || goto :fail

echo Build Sphinx
REM Invoke the selected Python directly, without relying on make discovery.
call :run "%COGS_PYTHON%" -m sphinx -M dirhtml "%SDTL_OUTPUT_ROOT%\sphinx\source" "%SDTL_OUTPUT_ROOT%\sphinx\build" || goto :fail

popd
endlocal & exit /b 0

:run
call %*
exit /b %errorlevel%

:fail
set "BUILD_EXIT=%errorlevel%"
if "%BUILD_EXIT%"=="0" set "BUILD_EXIT=1"
echo Build failed with exit code %BUILD_EXIT%.
popd
endlocal & exit /b %BUILD_EXIT%
