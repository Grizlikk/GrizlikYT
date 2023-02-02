@echo off
title Overeni pro cislo
color e

rem Program, do kterého uživatel zadá čísla a program ověří, jestli jsou to opravdu čísla
:start
set /p cislo1=Zadejte prvni cislo: 
rem Ověření musí být pro každou proměnnou zvlášť
set /a a = %cislo1%
if %cislo1% neq %a% cls & echo Neplatne zadani! & echo. & goto start

set /p cislo2=Zadejte druhe cislo: 
set /a a = %cislo2%
if %cislo2% neq %a% cls & echo Neplatne zadani! & echo. & goto start

set /p cislo3=Zadejte treti cislo: 
set /a a = %cislo3%
if %cislo3% neq %a% cls & echo Neplatne zadani! & echo. & goto start

set /p cislo4=Zadejte ctvrte cislo: 
set /a a = %cislo4%
if %cislo4% neq %a% cls & echo Neplatne zadani! & echo. & goto start

set /p cislo5=Zadejte pate cislo: 
set /a a = %cislo5%
if %cislo5% neq %a% cls & echo Neplatne zadani! & echo. & goto start

rem Testovací výpis
echo.
echo Uzivatel zadal cisla: %cislo1%, %cislo2%, %cislo3%, %cislo4%, %cislo5%
pause > nul
exit /b 0