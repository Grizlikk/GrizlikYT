@echo off
title Program
color 6

set /p promenna=Zadejte cislo: 
set /a promenna=%promenna%*2
echo %promenna%
pause