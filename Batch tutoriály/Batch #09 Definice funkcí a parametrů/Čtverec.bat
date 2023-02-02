@echo off
title Ctverec
color 9

set /p strana=Zadejte delku strany: 
rem call :overenizadani

echo.
call :Informace %strana%
call :Obvod %strana% o
call :Obsah %strana% s

echo Obvod: %o%
echo Obsah %s%

pause > nul
exit 0

:Informace
echo Delka strany ctverce je: %~1
goto :eof


:Obvod
set /a %~2=4*%~1
goto :eof


:Obsah
set /a %~2=%~1*%~1
goto :eof