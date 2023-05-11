@echo off
title IP Adresy

for /f "tokens=2 delims=;" %%a in (IP.txt) do (
    echo IP adresa: %%a
)


pause > nul
exit /b 0