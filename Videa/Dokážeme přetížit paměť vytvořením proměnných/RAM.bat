@echo off
title RAM
setlocal enabledelayedexpansion

rem Počet průchodů cyklem k vytváření proměnných
set /p ram=Zadejte mnozstvi pruchodu: 

rem Vytvoření proměnné "text", která však může mít maximálně 4 kB
set text=abcdefghijklmnopqrstuvwxyz123456789
for /l %%i in (1, 1, 10) do (set text=!text!!text!)

rem Cyklus k plnění paměti proměnnými
for /l %%i in (1, 1, %ram%) do (set promenna%%i=!text!)

rem Konec programu
pause
goto :eof