@echo off
title Funkce

call :funkce "Tohle jsou parametry" "Druhý parametr"

pause > nul
exit /b 0

:funkce
echo %~1
goto :eof