@echo off
title Login
color b

echo Pro pokracovani se musite prihlasit...
set /p heslo=Zadejte heslo: 

if "tajneheslo" == "%heslo%" (set /a login=1) else (set /a login=0)

if %login% == 1 start tajny_soubor.txt

pause > nul
exit /b 0