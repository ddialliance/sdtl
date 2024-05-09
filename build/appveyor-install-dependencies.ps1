# Download COGS
#Start-FileDownload 'http://ci.appveyor.com/api/projects/DanSmith/cogs/artifacts/Cogs.Console/bin/Release/netcoreapp2.1/Windows-CogsRelease.zip'
#7z x Windows-CogsRelease.zip -y -o"cogs"

#dotnet tool install -g cogs
#cogs --help

# Development versions can be installed from the appveyor nuget feed
dotnet tool install -g --add-source https://ci.appveyor.com/nuget/cogs/ cogs



# Download Graphviz
$wc = New-Object System.Net.WebClient

$wc.DownloadFile("https://graphviz.gitlab.io/_pages/Download/windows/graphviz-2.38.zip", "graphviz-2.38.zip")
& "${env:ProgramFiles}\7-Zip\7z.exe" x build/graphviz-2.38.zip -y -o"build/graphviz"

# Download Sphinx
pip install sphinx
pip install sphinx_rtd_theme
