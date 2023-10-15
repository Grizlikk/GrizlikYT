@echo off
title Jmeno pocitace
color e

for /f "tokens=3" %%a in ('systeminfo ^| find "Host Name"') do (
    echo Nazev vaseho pocitace je: %%a
)

pause > nul
exit /b 0