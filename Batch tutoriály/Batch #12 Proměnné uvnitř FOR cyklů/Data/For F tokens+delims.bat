@echo off
title FOR /F tokens+delims

for /f "tokens=1,2,* delims=;" %%a in (IP.txt) do (
    echo Nazev: %%a   IP: %%b   Popis: %%c
)


pause > nul
exit /b 0