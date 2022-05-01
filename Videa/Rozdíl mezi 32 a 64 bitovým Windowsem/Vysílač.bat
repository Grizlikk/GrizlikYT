@echo off
color 4
title Vysilac
rem Cesta do mojí sdílené složky, pro použití jiné sdílené složky je nutné přepsat tuto cestu ke složce
D:
cd D:\VM\.Shared
if exist new del new

:a
echo.
set /p prikaz=Poslete Grizlikovi odber a take prikaz do virtualniho pocitace: 
rem Program vytvoří soubor "Prenos", do kterého uloží požadovaný příkaz
echo %prikaz%> Prenos
echo. > new
timeout /t 1 > nul
del new
timeout /t 1 > nul
goto a