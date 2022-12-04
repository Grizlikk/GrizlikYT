@echo off
title Kontrola pro opravneni spravce
color e
net session
cls

if %errorlevel% neq 0 (echo Nejste administrator) else (echo Jste administrator)

pause
exit /b 5