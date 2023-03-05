@echo off
color c
title Aktivace Windows

if "%OS%" neq "Windows_NT" goto error
net session & cls
if %errorlevel% neq 0 powershell /C "Start-Process -Verb RunAs -FilePath '%0'" & exit

echo Zjistovani potrebnych informaci...
echo.
for /f "tokens=* usebackq" %%i in (`systeminfo^|find "OS Name"`) do (
    set ver=%%i
    )
if "%ver:~-4%"=="Home" (set ver=Home& set /a ed=%ver:~-7,-5%) else (set ver=Pro& set /a ed=%ver:~-6,-4%)

if "%ed%" neq "10" if "%ed%" neq "11" goto error
if "%ver%" neq "Home" if "%ver%" neq "Pro" goto error

title Aktivace Windows %ed% %ver%
cls
echo Stisknete enter pro aktivaci Windows %ed% %ver%
echo Pro zruseni aktivace zavrete aplikaci...
pause > nul

cls
echo Probiha aktivace...
if "%ver%" == "Pro" (start slmgr /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX) else (start slmgr /ipk TX9XD-98N7V-6WMQ6-BX7FG-H8Q99)
timeout /t 3 > nul
start slmgr /skms kms8.msguides.com
timeout /t 3 > nul
start slmgr /ato

echo.
echo Aktivace probehla uspesne! Nyni mejte navzdy spatny pocit z toho, ze jste neoficialne aktivovali Windows :D
pause > nul
exit /b

:error
echo.
echo ERROR!!! Nekde v programu doslo k chybe.
echo Program je urcen pouze pro aktivaci Windows 10 nebo 11 a to pouze pro verze Home a Pro
echo Pokud jse si jisti, ze vase instalace Windows splnuje tyto pozadavky, tak je program rozbity...
echo V takovemto pripade prepiste kod programu tak, aby pro vas fungoval :DDD
pause > nul
exit /b