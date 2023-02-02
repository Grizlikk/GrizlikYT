@echo off
title Overeni pro cislo
color e

rem Program, do kterého uživatel zadá čísla a program ověří, jestli jsou to opravdu čísla
:start
set /p cislo1=Zadejte prvni cislo: 
call :JeCislo %cislo1%
set /p cislo2=Zadejte druhe cislo: 
call :JeCislo %cislo2%
set /p cislo3=Zadejte treti cislo: 
call :JeCislo %cislo3%
set /p cislo4=Zadejte ctvrte cislo: 
call :JeCislo %cislo4%
set /p cislo5=Zadejte pate cislo: 
call :JeCislo %cislo5%

rem Testovací výpis
echo.
echo Uzivatel zadal cisla: %cislo1%, %cislo2%, %cislo3%, %cislo4%, %cislo5%
pause > nul
exit /b 0

rem Funkce pro kontrolu, jestli proměnná je číslo nebo text
rem Pokud příkaz "set /a" obdrží text místo čísla, automaticky to z toho udělá číslo 0
:JeCislo
set /a a = %~1
rem Pokud je proměnná "a" rovna 0, ale není stejná, jako originální proměnná (protože i 0 může být číslo) program se vrátí na začátek
if %~1 neq %a% cls & echo Neplatne zadani! & echo. & goto start

goto :eof