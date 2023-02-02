@echo off
title Funkce

call :nazev
call :nazev
call :nazev

pause > nul
exit /b 0

:nazev
echo Ahoj
echo Nazdar
echo Cau
goto :eof