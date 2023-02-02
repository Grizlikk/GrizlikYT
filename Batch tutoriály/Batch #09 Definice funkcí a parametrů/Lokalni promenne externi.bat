@echo off
title Lokalni promenne
color e

rem Program, do kterého uživatel zadá čísla a program ověří, jestli jsou to opravdu čísla
set /p a=Zadejte prvni cislo: 
call JeCislo2 %a%
set /p b=Zadejte druhe cislo: 
call JeCislo2 %b%
set /p c=Zadejte treti cislo: 
call JeCislo2 %c%

rem Testovací výpis
echo.
echo Uzivatel zadal cisla: %a%, %b%, %c%
pause > nul
exit 0