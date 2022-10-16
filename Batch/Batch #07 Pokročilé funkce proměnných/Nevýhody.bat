@echo off
set /a a=5
set /a vysledek = 10

if %a% == 5 (
    set /a vysledek = %a% * %a%
    echo %vysledek%
)

echo %vysledek%

pause