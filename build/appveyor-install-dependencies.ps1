pwd

# Download COGS
Start-FileDownload 'http://ci.appveyor.com/api/projects/DanSmith/cogs/artifacts/Cogs.Console/bin/Release/netcoreapp2.0/Windows-CogsRelease.zip'
7z e Windows-CogsRelease.zip -y

# Download Graphviz
Start-FileDownload 'http://www.graphviz.org/pub/graphviz/stable/windows/graphviz-2.38.zip'
7z e graphviz-2.38.zip -y -o"graphviz"
ls graphviz\bin

# Download Sphinx
pip install sphinx
pip install sphinx_rtd_theme
