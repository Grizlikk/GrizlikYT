@echo off
title Lokalni promenne
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
rem V této oblasti bude proměnná %a% něco jiného, než mimo SETLOCAL, všechny tyto proměnné jsou nepřístupné mimo SETLOCAL
SETLOCAL
set /a a = %~1
if %~1 neq %a% cls & echo Neplatne zadani! & echo. & goto start
rem Zde končí oblast SETLOCAL, což způsobí smazání všech lokálních proměnných a navrácení jejich původních hodnot
ENDLOCAL
goto :eof