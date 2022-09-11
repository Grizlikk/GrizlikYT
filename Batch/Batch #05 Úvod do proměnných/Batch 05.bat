@echo off
title Batch 05
color f0
:start
rem Zadání čísla
set /p cislo=Zadejte cislo: 
rem Výpočet
set /a cislo = (%cislo% + %random% - %random%) * %random% / %random%
rem Výpis
echo Vase upravene cislo je: %cislo%
echo.
echo Stisknete jakoukoliv klavesu pro zadani dalsiho cisla...
pause > nul
cls
goto start