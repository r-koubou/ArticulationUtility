#!/bin/bash

pack()
{
    echo "----------------------------------------"
    echo "$1 ($2)"
    echo "----------------------------------------"
    pushd $1
        dotnet pack --nologo -o ../.nuget/ -c $2
    popd
}

pack Controllers Debug
pack Entities Debug
pack ExternalTranslators Debug
pack FileAccessors Debug
pack Gateways Debug
pack Interactors Debug
pack Presenters Debug
pack UseCases Debug
pack Utilities Debug