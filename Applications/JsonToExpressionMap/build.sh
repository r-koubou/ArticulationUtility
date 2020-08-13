#!/bin/bash

dotnet msbuild /nologo /t:Archive /p:Configuration=Release build.msbuild
dotnet msbuild /nologo /t:Archive /p:Configuration=Release /p:RID=osx-x64 build.msbuild
dotnet msbuild /nologo /t:Archive /p:Configuration=Release /p:RID=win-x64 build.msbuild
