# Push the dirhtml subdirectory to Gitlab Pages
PUSHD out\sphinx\build

git config --global credential.helper store
Add-Content "$env:USERPROFILE\.git-credentials" "https://$env:access_token:x-oauth-basic@gitlab.com`n"
git config --global user.name "AppVeyor"
git config --global user.email "build@c2metadata.org"

git clone https://gitlab.com/c2metadata/sdtl-docs.git --depth 1
PUSHD sdtl-docs
Copy-Item ..\dirhtml\* master -Force

git add master
git commit -m 'docs'
git push -u origin master

POPD
POPD

