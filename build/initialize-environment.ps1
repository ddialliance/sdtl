# Download COGS
Start-FileDownload 'https://ci.appveyor.com/api/buildjobs/n95t2byfet043px6/artifacts/Cogs.Console/bin/Release/Windows-CogsRelease.zip'
7z e Windows-CogsRelease.zip -y

# Download Graphviz
Start-FileDownload 'http://www.graphviz.org/pub/graphviz/stable/windows/graphviz-2.38.zip'
7z e graphviz-2.38.zip -y

# Download Sphinx
pip install sphinx
