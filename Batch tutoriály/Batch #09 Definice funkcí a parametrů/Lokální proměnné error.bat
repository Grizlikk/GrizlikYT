@echo off
title Lokalni promenne error
color e

rem Program, do kterého uživatel zadá čísla a program ověří, jestli jsou to opravdu čísla
:start
set /p a=Zadejte prvni cislo: 
call :JeCislo %a%
set /p b=Zadejte druhe cislo: 
call :JeCislo %b%
set /p c=Zadejte treti cislo: 
call :JeCislo %c%

rem Testovací výpis
echo.
echo Uzivatel zadal cisla: %a%, %b%, %c%
pause > nul
exit /b 0

rem Funkce pro kontrolu, jestli proměnná je číslo nebo text
:JeCislo
set /a a = %~1
if %~1 neq %a% cls & echo Neplatne zadani! & echo. & goto start
goto :eof