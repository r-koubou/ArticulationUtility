@echo off

set THIS_DIR=%~dp0%

echo %THIS_DIR%

if not exist "publish"\ (
    mkdir publish
)

rem Publish all applications
for /D %%i in (*) do (
    if not %%i == "publish" if exist "%%i\publish.bat" (
        echo ----- %%i --------------
        pushd "%%i"
            call .\publish.bat
            rem Copy all applications zip to ./publish folder
            pushd .\publish\
                copy /y *.zip %THIS_DIR%\publish\
            popd
            rem cleanup
            rd /s /q .\publish\
        popd
    )
)
