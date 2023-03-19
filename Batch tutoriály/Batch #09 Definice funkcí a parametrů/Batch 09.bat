@echo off
title Obdelniky
color 9

:start
rem Zadání šířky a výšky obdélníka (nebo obdélníku???) :D
set /p sirka=Zadejte sirku obdelnika: 
rem Ověření, že vstup není ani text, ani menší nebo roven 0
call :OvereniKladneCislo %sirka%
set /p vyska=Zadejte vysku obdelnika: 
call :OvereniKladneCislo %vyska%

rem Spuštění funkcí a výpis parametrů obdélníka
echo.
call :InformaceObdelnik %sirka% %vyska%
call :ObvodObdelnika %sirka% %vyska% obvod
echo Obvod: %obvod%
call :ObsahObdelnika %sirka% %vyska% obsah
echo Obsah: %obsah%

rem ZDE MUSÍTE PROGRAM UKONČIT PŘÍKAZEM "EXIT", JINAK SE KÓD FUNKCÍ SPUSTÍ A ZPŮSOBÍ CHYBU PROGRAMU!
pause > nul
exit 0

rem Definice funkcí v programu
:OvereniKladneCislo
rem Příkaz "set /a" automaticky z textu udělá 0, číslo 0 nebo menší je však v tomto případě také neplatné zadání
set /a a = %~1
if "%a%" == "" cls & echo Neplatne zadani! & echo. & goto start
if %a% leq 0 cls & echo Neplatne zadani! & echo. & goto start
goto :eof


:ObsahObdelnika
rem Funkce pro výpočet obsahu obdélníka, poslední argument je proměnná, do které se uloží výsledek
set /a %~3 = %~1 * %~2
goto :eof


:ObvodObdelnika
rem Funkce pro výpočet obvodu obdélníka, poslední argument je proměnná, do které se uloží výsledek
set /a %~3 = 2 * (%~1 + %~2)
goto :eof


:InformaceObdelnik
rem Funkce pro výpis šířky a výšky obdélníka
echo Sirka obdelnika je: %~1
echo Vyska obdelnika je: %~2
goto :eof