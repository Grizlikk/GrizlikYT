@echo off
title Generovani
setlocal enabledelayedexpansion

for /l %%i in (1, 1, 1000) do (
    echo !random! > "Soubor %%i.txt"
)

echo Generovani dokonceno!
pause > nul
exit /b 0