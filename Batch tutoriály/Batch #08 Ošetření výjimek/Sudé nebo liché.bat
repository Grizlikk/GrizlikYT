@echo off
title Sude / Liche
color e

set /p cislo=Zadejte cislo: 

set /a prom = %cislo% %% 2

if %prom% == 0 echo Cislo je sude
if %prom% == 1 echo Cislo je liche

pause