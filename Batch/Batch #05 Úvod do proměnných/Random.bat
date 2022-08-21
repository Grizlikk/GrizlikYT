@echo off
title %random%
color 6

:reset
set /a cislo=%random%
set /a cislo=%cislo%*100
set /a cislo=%cislo%/32768
set /a cislo=%cislo%+1
echo %cislo%
goto reset