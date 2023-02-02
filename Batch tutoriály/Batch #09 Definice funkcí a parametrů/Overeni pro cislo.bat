@echo off
title Overeni pro cislo
color e

rem Program, do kterého uživatel zadá čísla a program ověří, jestli jsou to opravdu čísla
set /p cislo1=Zadejte prvni cislo: 
call JeCislo %cislo1%
set /p cislo2=Zadejte druhe cislo: 
call JeCislo %cislo2%
set /p cislo3=Zadejte treti cislo: 
call JeCislo %cislo3%
set /p cislo4=Zadejte ctvrte cislo: 
call JeCislo %cislo4%
set /p cislo5=Zadejte pate cislo: 
call JeCislo %cislo5%

rem Testovací výpis
echo.
echo Uzivatel zadal cisla: %cislo1%, %cislo2%, %cislo3%, %cislo4%, %cislo5%
pause > nul
exit 0