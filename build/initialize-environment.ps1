pwd

# Download COGS
Start-FileDownload 'http://ci.appveyor.com/api/projects/DanSmith/cogs/artifacts/Cogs.Console/bin/Release/netcoreapp2.0/Windows-CogsRelease.zip'
7z e Windows-CogsRelease.zip -y

# Download Graphviz
Start-FileDownload 'http://www.graphviz.org/pub/graphviz/stable/windows/graphviz-2.38.zip'
7z e graphviz-2.38.zip -y -o"graphviz"
ls graphviz\bin

# Download .NET Core 2.0 Preview 2 SDK and add to PATH
$urlCurrent = "https://download.microsoft.com/download/F/A/A/FAAE9280-F410-458E-8819-279C5A68EDCF/dotnet-sdk-2.0.0-preview2-006497-win-x64.zip"
$env:DOTNET_INSTALL_DIR = "$pwd\.dotnetsdk"
$tempFileCurrent = [System.IO.Path]::GetTempFileName()
(New-Object System.Net.WebClient).DownloadFile($urlCurrent, $tempFileCurrent)
Add-Type -AssemblyName System.IO.Compression.FileSystem; [System.IO.Compression.ZipFile]::ExtractToDirectory($tempFileCurrent, $env:DOTNET_INSTALL_DIR)
$env:Path = "$env:DOTNET_INSTALL_DIR;$env:Path"  

# Download Sphinx
pip install sphinx
pip install sphinx_rtd_theme
