@echo off
setlocal enabledelayedexpansion
rem Kontrola o oprávnění správce a nastavení titulku
net session
if %errorlevel% == 0 (set /a admin=1) else (set /a admin=0)
title C:\Windows\system32\cmd.exe
cls
rem Výpis textu podobný příkazovému řádku
echo Microsoft Windows [Version 10.0.19069.1569]
echo (c) Microsoft Corporation. Vsechna prava vyhrazena.
echo.

:r
rem Výpis textu jako v příkazovém řádku
set /p prikaz=%cd%^>
rem V případě příkazu powershell wininit se spustí sfc /scannow
if "%prikaz%" == "powershell wininit" (
    if %admin% == 1 (
        @echo on
        sfc /scannow
        @echo off
    )
rem V případě příkazu taskkill /f /im svchost.exe se vypíše text jako že se svchost.exe ukončil
) else if "%prikaz%" == "taskkill /f /im svchost.exe" (
    for /l %%i in (1, 1, 30) do echo SUCCESS: The process "svchost.exe" with PID !random! has been terminated.
    taskkill /f /im wordpad.exe > nul
rem Pokud se jedná o jakýkoliv text, program jej spustí jako příkaz
) else (%prikaz%)
echo.
goto r