#! /bin/sh

project=$1
version=$2
package_path=$(pwd)/current-package/$project.unitypackage
release_directory=$(pwd)/release
release_path=$release_directory/$project.$version.unitypackage

mkdir -p $release_directory

echo "Preparing release version $version."
cp "$package_path" "$release_path"
