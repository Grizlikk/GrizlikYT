@echo off
title Nahodne cisla
setlocal EnableDelayedExpansion

set /p pocet=Zadejte pocet nahodnych cisel: 
echo.

for /l %%i in (1, 1, %pocet%) do (
    echo !random!
)

pause > nul
exit /b 0