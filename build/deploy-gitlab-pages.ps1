REM Push the dirhtml subdirectory to Gitlab Pages
PUSHD out\sphinx\build
git config --global credential.helper store
Add-Content "$env:USERPROFILE\.git-credentials" "https://$($env:access_token):x-oauth-basic@github.com`n"
git config --global user.name "AppVeyor"
git config --global user.email "build@c2metadata.org"
git init
git remote add gitlabpages git@gitlab.com:c2metadata/sdtl-docs.git
git add dirhtml
git commit -m 'docs'
git subtree push --prefix dirhtml gitlabpages master
POPD

