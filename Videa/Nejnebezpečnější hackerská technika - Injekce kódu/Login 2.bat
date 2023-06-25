@echo off
title Login
color b

echo Pro pokracovani se musite prihlasit...
set /p heslo=Zadejte heslo: 

if "tajneheslo" == "%heslo%" start tajny_soubor.txt

pause > nul
exit /b 0