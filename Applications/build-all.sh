#!/bin/bash

dir_path="./*"
dirs=`find $dir_path -maxdepth 0 -type d`

this_dir=`pwd`

if [ ! -d publish/ ] ; then
    mkdir publish/
fi

# Build all applications
for i in $dirs
do
    if [ -e "$i/build.sh" ] ; then
        echo ----- $i --------------
        pushd "$i"
            ./build.sh
            # Copy all applications zip to ./publish folder
            pushd publish/
                cp *.* "$this_dir"/publish/
            popd
        popd
    fi
done
