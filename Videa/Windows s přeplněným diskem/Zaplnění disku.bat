@echo off
color 4
title Zaplneni mista

set /a i=1
:a
echo.>%i%.txt
:cop
type %i%.txt>>%i%.txt
if %errorlevel%==0 goto cop

set /a i+=1
goto a