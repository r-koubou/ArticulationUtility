@echo off

dotnet msbuild /nologo /t:Archive /p:Configuration=Release publish.msbuild
