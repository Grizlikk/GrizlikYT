@echo off
color b
title Matematika

:zacatek
rem Zadání počtu příkladů
set /p priklady=Zvolte pocet prikladu: 

rem Ověření správnosti zadání
rem Text uvnitř "set /a" dá výsledek 0
set /a a = %priklady%
if %a% leq 0 (
    cls
    echo Neplatna hodnota!
    goto zacatek
)

rem Reset příkazu %random%, aby negeneroval podobné hodnoty:
set /a a=%random%
set /a a=%random%

rem Definice proměnných
set /a pocet = 0
set /a SpravneOdpovedi = 0

cls

rem Cyklus celého programu
:start

rem Vybírání operace
set /a operace = %random% * 4 / 32768 + 1

rem Generování čísel
if %operace% == 1 (set znamenko=+ & set /a a = %random% * 50 / 32768 + 1 & set /a b = %random% * 50 / 32768 + 1 & goto vypocet)
if %operace% == 2 (set znamenko=- & set /a a = %random% * 100 / 32768 + 1 & set /a b = %random% * 100 / 32768 + 1)
if %operace% == 3 (set znamenko=* & set /a a = %random% * 10 / 32768 + 1 & set /a b = %random% * 10 / 32768 + 1 & goto vypocet)

rem Ošetření chybných vygenerování
rem Prohození čísel pro odčítání, aby nevyšel záporný výsledek
set /a c = %a%
if %operace% == 2 (if %a% lss %b% (set /a a = %b% & set /a b = %c%) & goto vypocet)

rem Generování dělení a ošetření, aby nevyšel desetinný výsledek
set znamenko=/ 
:deleni

set /a a = %random% * 100 / 32768 + 1
set /a b = %random% * 10 / 32768 + 1

set /a c = %a% %% %b%
if %c% neq 0 goto deleni


rem Počítání příkladů
:vypocet
if %pocet% == %priklady% goto konec
set /a pocet += 1

rem Generování možných odpovědí
set /a spravne = %a% %znamenko% %b%
:gen
set /a x = %random% * 100 / 32768 + 1
set /a y = %random% * 100 / 32768 + 1
set /a z = %random% * 100 / 32768 + 1
if %x% == %y% goto gen
if %y% == %z% goto gen
if %z% == %x% goto gen
if %x% == %spravne% goto gen
if %y% == %spravne% goto gen
if %z% == %spravne% goto gen

rem Pořadí výpisu možných odpovědí
set /a poradi = %random% * 4 / 32768 + 1

rem Výpis příkladu
echo %pocet%.) %a% %znamenko%%b% =

rem Na pořadí proměnných x,y,z nezáleží, protože jsu to náhodná čísla
if %poradi% == 1 (
    echo A: %spravne%
    echo B: %x%
    echo C: %y%
    echo D: %z%
)
if %poradi% == 2 (
    echo A: %x%
    echo B: %spravne%
    echo C: %y%
    echo D: %z%
)
if %poradi% == 3 (
    echo A: %y%
    echo B: %x%
    echo C: %spravne%
    echo D: %z%
)
if %poradi% == 4 (
    echo A: %z%
    echo B: %x%
    echo C: %y%
    echo D: %spravne%
)

choice /c ABCD /m "Odpoved: " /n
if %ERRORLEVEL% == %poradi% (echo Spravne! & set /a SpravneOdpovedi += 1) else (echo Spatne, spravna odpoved byla: %spravne%)
echo.

goto start

rem Konec programu
:konec
echo.
echo.
echo.
set /a uspesnost = %SpravneOdpovedi% * 100 / %priklady%
echo Celkovy spravny pocet odpovedi: %SpravneOdpovedi% z %priklady%, to je %uspesnost%%% uspesnost
echo Dekujeme za zahrani hry
pause > nul
rem Ukončení souboru s kódem 0
exit /b 0