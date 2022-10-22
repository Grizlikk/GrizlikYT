@echo off
title Porovnani
color e

set a=5

if %a% == 5 echo Ahoj1
if %a% neq 5 echo Ahoj2
if %a% lss 5 echo Ahoj3
if %a% leq 5 echo Ahoj4
if %a% gtr 5 echo Ahoj5
if %a% geq 5 echo Ahoj6

rem ==
rem !=
rem <
rem <=
rem >
rem >=

echo.>soubor.txt

pause