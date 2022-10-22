@echo off
title %random%
color 6

:reset
set /a cislo=(%random%*100/32768)+1
echo %cislo%
goto reset