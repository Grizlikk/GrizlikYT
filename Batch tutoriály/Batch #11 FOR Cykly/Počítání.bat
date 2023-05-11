@echo off
title Pocitani do 1000

for /l %%i in (1, 1, 1000) do (
    echo %%i
    timeout /t 1 > nul
)


pause > nul
exit /b 0