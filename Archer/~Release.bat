:: Create Archer release package
@echo off
set p=bin\Release
::zip -j -u "%p%\Archer_0.0.0.0.zip" "%p%\Archer.exe" "%p%\UserData.xml" "%p%\*.dll" "Documentation\Archer.chm"
::start "" "%p%"

:: Personal part y.s.
copy "%p%\Archer.exe" "%programfiles%\Archer"
::copy "Lib\*.dll" "E:\Archer"
copy "Documentation\Archer.chm"  "bin\Release\"
copy "Documentation\Archer.chm"  "%programfiles%\Archer"

pause