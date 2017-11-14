set cogs=dotnet ~/bin/cogs/Cogs.Console.dll
set out=/mnt/c/svn/sdtl-reader/src/C2Metadata.Common/Model2

$cogs publish-cs . $out --overwrite
