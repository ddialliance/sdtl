# Copy the artifact zip to the sphinx _static directory
copy sdtl.zip sdtl\sphinx\build\dirhtml\_static\

# Push the dirhtml subdirectory to Gitlab Pages
PUSHD sdtl\sphinx\build

git config --global credential.helper store
Add-Content "$env:USERPROFILE\.git-credentials" "https://$($env:access_token)@gitlab.com`n"
git config --global user.name "AppVeyor"
git config --global user.email "build@c2metadata.org"

git clone https://gitlab.com/c2metadata/sdtl-docs.git
PUSHD sdtl-docs
Copy-Item ..\dirhtml\* master -Force -Recurse

git add master
git commit -m 'docs'
git push -u origin master

POPD
POPD

