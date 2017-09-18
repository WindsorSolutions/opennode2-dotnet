@echo off
rem %1 is the project directory
rem	%2 is the directory containing updateversion
rem	%3 is the assemblyinfo file
echo PREBUILD: Working on %3
copy %3.template %3 >NUL
copy %3 %3.orig
%2\UpdateVersion.exe -i %3 -o %3 -m -v Informational
echo Assembly info updated to reflect Hg version

