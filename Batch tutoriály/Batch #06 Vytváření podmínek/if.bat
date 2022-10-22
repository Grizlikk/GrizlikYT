@echo off
title IF
color e

if 5 == 6 (echo 5 je stejne jako 6)
if 6 < 9 (echo 6 je mensi nez 9)
if defined promenna (echo hodnota promenne "promenna" je %promenna%)
if exist soubor.txt (echo soubor.txt existuje)
if not exist "C:\Program files\chrome" (echo Proc nepouzivate Google chrome?)
set /p cislo=Zadejte cislo mensi nez 10: 
if %cislo% lss 10 (echo Spravne!) else (echo Spatne!)
pause > nul
exit