@echo off
setlocal EnableExtensions DisableDelayedExpansion
set "DOT_PATH_FILE="

REM Resolve the model independently of the caller's working directory.
for %%I in ("%~dp0..") do set "MODEL_ROOT=%%~fI"

REM COGS 2 publication targets must be outside the model source directory.
REM SDTL_OUTPUT_ROOT can override the default for local builds.
if not defined SDTL_OUTPUT_ROOT if defined RUNNER_TEMP set "SDTL_OUTPUT_ROOT=%RUNNER_TEMP%\sdtl-outputs"
if not defined SDTL_OUTPUT_ROOT set "SDTL_OUTPUT_ROOT=%TEMP%\sdtl-outputs"
for %%I in ("%SDTL_OUTPUT_ROOT%") do set "SDTL_OUTPUT_ROOT=%%~fI"
if not defined COGS_PYTHON set "COGS_PYTHON=python"

pushd "%MODEL_ROOT%" || exit /b 1
echo Build outputs: %SDTL_OUTPUT_ROOT%

echo Check COGS RDF support
call :run cogs publish-rdf --help >nul || goto :cogs_incompatible

echo Check Graphviz dependency
set "DOT_PATH_FILE=%TEMP%\sdtl-graphviz-%RANDOM%-%RANDOM%.txt"
call :run pwsh -NoProfile -File "%MODEL_ROOT%\build\install-dependencies.ps1" -DotPathFile "%DOT_PATH_FILE%" || goto :fail
set /p "COGS_DOT=" < "%DOT_PATH_FILE%" || goto :fail
del /q "%DOT_PATH_FILE%"
set "DOT_PATH_FILE="
set DOT_OPTION=--dot "%COGS_DOT%"

echo Validate
call :run cogs validate "%MODEL_ROOT%" || goto :fail

echo JSON
call :run cogs publish-json "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\json" --overwrite || goto :fail

echo GraphQL
call :run cogs publish-graphql "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\graphql" --overwrite || goto :fail

echo XSD
call :run cogs publish-xsd "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\xsd" --overwrite --namespace "https://rdf-vocabulary.ddialliance.org/sdtl#" --namespacePrefix sdtl || goto :fail

echo DCTAP
call :run cogs publish-dctap "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\dctap" --overwrite || goto :fail

echo UML
call :run cogs publish-uml "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\uml" --mode ea %DOT_OPTION% --overwrite || goto :fail

echo RDF
call :run cogs publish-rdf "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\rdf" --overwrite || goto :fail

echo LinkML
call :run cogs publish-linkml "%MODEL_ROOT%" "%SDTL_OUTPUT_ROOT%\linkml" --overwrite || goto :fail

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

:cogs_incompatible
echo This build requires COGS with publish-rdf support. Update the COGS tool before building.
goto :fail

:fail
set "BUILD_EXIT=%errorlevel%"
if "%BUILD_EXIT%"=="0" set "BUILD_EXIT=1"
if defined DOT_PATH_FILE if exist "%DOT_PATH_FILE%" del /q "%DOT_PATH_FILE%"
echo Build failed with exit code %BUILD_EXIT%.
popd
endlocal & exit /b %BUILD_EXIT%
