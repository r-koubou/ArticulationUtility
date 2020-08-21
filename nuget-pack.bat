@echo off

:pack
    echo "----------------------------------------"
    echo "%1 (%2)"
    echo "----------------------------------------"
    pushd %1
        dotnet pack --nologo -o ..\.nuget\ -c %2
    popd
    exit /b 0

call :pack Controllers Debug
call :pack Entities Debug
call :pack ExternalTranslators Debug
call :pack FileAccessors Debug
call :pack Gateways Debug
call :pack Interactors Debug
call :pack Presenters Debug
call :pack UseCases Debug
call :pack Utilities Debug
