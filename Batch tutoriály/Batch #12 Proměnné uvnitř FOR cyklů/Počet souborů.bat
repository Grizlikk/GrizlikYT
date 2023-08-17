@echo off
title Pocet souboru
setlocal EnableDelayedExpansion

set /a soubory = 0
for %%s in (*) do (
    set /a soubory += 1
    echo !soubory!. %%s
)

echo.
echo Celkove mnozstvi souboru: %soubory%

pause > nul
exit /b 0