@echo off
rem %1 is the project directory
rem	%2 is the directory containing svnRev and updateversion
rem	%3 is the assemblyinfo file
echo POSTBUILD: Working on %1
if exist %3.orig copy %3.orig %3
if exist %3.orig del %3.orig 

