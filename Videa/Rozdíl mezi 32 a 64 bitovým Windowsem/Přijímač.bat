@echo off
title Prijimac
rem Cesta do sdílené složky
if exist Z: Z: & echo Probiha prijem ze slozky Z: ......

rem Kontrola pro soubor "new"
:a
timeout /t 0 > nul
if exist new call :start
goto a

rem V případě nalezení souboru "new" se spustí příkaz uložený v souboru "Prenos"
:start
set /p prikaz=< Prenos
%prikaz%
timeout /t 2 > nul
goto a