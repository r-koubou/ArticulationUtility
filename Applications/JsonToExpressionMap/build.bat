@echo off

dotnet msbuild /nologo /t:Archive /p:RID=osx-x64 build.msbuild
dotnet msbuild /nologo /t:Archive /p:RID=win-x64 build.msbuild
