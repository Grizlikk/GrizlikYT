@echo off
title Batch 06

rem Úvod
:zacatek
color e
echo ============================================================
echo           HRA O HADANI CISEL (VYLEPSENA EDICE!)
echo ============================================================
echo.
echo.
echo Vyberze obtiznost hry:
echo.
echo [Velmi lehka]:  1 - 10
echo [Lehka]:        1 - 100
echo [Stredni]:      1 - 500
echo [Tezka]:        1 - 10 000
echo [Velmi tezka]:  1 - 32 767
echo [Bonusova]:     -32 767 - 32 767
echo.
set /p level=Zadejte obtiznost: 


rem Přímé použití generování náhodných čísel má tendenci generovat podobná čísla, proto radši příkaz %random% použiji napřed naprázdno a až poté doopravy
set /a rand = %random%
set /a rand = %random%
rem Rozdělení obtížností
if "%level%" == "Velmi lehka" (set /a rand = %random% * 10 / 32768 + 1 & color f & goto next)
if "%level%" == "Lehka"       (set /a rand = %random% * 100 / 32768 + 1 & color 7 & goto next)
if "%level%" == "Stredni"     (set /a rand = %random% * 500 / 32768 + 1 & color 8 & goto next)
if "%level%" == "Tezka"       (set /a rand = %random% * 10000 / 32768 + 1 & color c & goto next)
if "%level%" == "Velmi tezka" (set /a rand = %random% & color 4 & goto next)
rem Bonusová obtížnost
set /a bonus = %random% * 2 / 32768
rem Proměnná Bonus určí znaménko
if "%level%" == "Bonusova"    ((if %bonus% == 1 (set /a rand = %random%) else (set /a rand = -%random%)) & color 5 & goto next)
rem Pokud neplatí ani jedna podmínka, program se vrátí na začátek
cls
goto zacatek


rem Pokračování programu a hádání číslice
:next
cls
echo ============================================================
echo           HRA O HADANI CISEL (VYLEPSENA EDICE!)
echo ============================================================
echo.
set /p cislo=Nahodne cislo bylo vygenerovano, zadejte vas tip: 

rem Proměnná i obsahuje počet pokusů na uhádnutí čísla
set /a i=1


rem Tato část se bude opakovat, dokud uživatel číslo neuhodne
:hadani
cls
echo ============================================================
echo           HRA O HADANI CISEL (VYLEPSENA EDICE!)
echo ============================================================
rem Porovnání
if %cislo% lss %rand% echo Vice
if %cislo% gtr %rand% echo Mene
if %cislo% == %rand% goto win
echo.
rem Zvětšení počítadla pokusů o 1 a zadání nového tipu
set /a i+=1
set /p cislo=Zadejte dalsi tip: 
goto hadani


rem Tato část se spustí až uživatel uhádné číslo
:win
cls
echo ============================================================
echo          Gratuluji! Vami zadane cislo %cislo% je spravne!
echo           Podarilo se vam jej uhodnout na %i% pokusu
rem   Take nezapomente dat odber na YouTube kanal Grizlik :D
echo ============================================================
echo.
echo.

rem Možnost spušení nové hry
echo Chcete spustit novou hru? [A/N]
set /p reset=
cls
if %reset% == A goto zacatek
if %reset% == a goto zacatek
color e
echo Doufame, ze jste si hru uzili!
echo Take dekujeme, ze pouzivate Grizlikuv tutorial na vyuku jazyka Batch :D
timeout /t 5 > nul
exit
rem Kód tohoto souboru si můžete prohlédnout na: https://github.com/Grizlikk/GrizlikYT