@echo off
title Oprava systemu
color e

choice /c AN /m "Chcete spustit opravu systemovych souboru? [A/N]: " /n
if %errorlevel% == 2 echo Ukoncovani programu... & pause > nul & exit 0

net session
cls
if %errorlevel% neq 0 (echo Error! K teto akci potrebuje opravneni spravce & pause > nul & exit 5) else (sfc /scannow)

pause
exit /b 5