#! /bin/sh

project=$1
project_path=$(pwd)/src/$project
log_file=$(pwd)/build/unity-mac.log
export_directory=$(pwd)/current-package
export_path=$export_directory/$project.unitypackage
error_code=0

mkdir -p $export_directory

echo "Creating package."
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile "$log_file" \
  -projectPath "$project_path" \
  -exportPackage "Assets/$project" "$export_path" \
  -quit
if [ $? = 0 ] ; then
  echo "Created package successfully."
  error_code=0
else
  echo "Creating package failed. Exited with $?."
  error_code=1
fi

echo 'Build logs:'
cat $log_file

echo "Finishing with code $error_code"
exit $error_code
