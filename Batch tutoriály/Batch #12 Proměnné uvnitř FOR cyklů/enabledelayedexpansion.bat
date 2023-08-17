@echo off
title IP Adresy
setlocal EnableDelayedExpansion

set /a radek = 1
for /f "tokens=2 delims=;" %%a in (IP.txt) do (
    echo !radek!. IP adresa: %%a
    set /a radek += 1
)


pause > nul
exit /b 0