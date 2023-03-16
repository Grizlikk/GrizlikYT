@echo off
title Umela inteligence
color e
setlocal enabledelayedexpansion

:start
rem Trénování umělé inteligence
set /p tren=Zadejte uroven treninku od 0 do 10000000: 
rem Ověření zadání
if "%tren%" == "" goto start
set /a a=%tren%
if %a% neq %tren% goto start
if %a% lss 0 goto start
if %a% gtr 10000000 goto start

rem Trénink

rem Generování možností
echo Generuji moznoti odpovedi...
for /l %%a in (0, 1, 99) do (
    for /l %%b in (1, 1, 10) do (
        set /a cislo%%a[%%b]=%%b
    )
)

rem Hraní her proti generátoru náhodných čísel
set /a i=0
:trenovani
cls
echo Probiha trenovani...
echo Postup: %i% z %tren%
if %i% geq %tren% goto hra

rem Definice proměnných
set /a kolo=0
set /a soucet=0

:hratrenovani
rem Kontrola pro vyčerpání možností
set /a definovano=0
for /l %%a in (1, 1, 10) do (
    if defined cislo%soucet%[%%a] set definovano=1
)
if %definovano% == 0 for /l %%a in (1, 1, 10) do (set /a cislo%soucet%[%%a]=%%a)

rem Vybrání náhodné možnosti
:gen
set /a prog=%random%*10/32768+1
if not defined cislo%soucet%[%prog%] goto gen

rem Přičtení k součtu a kontrola pro výhru
set /a soucet+=%prog%
if %soucet% geq 100 set /a i+=1 & goto trenovani

rem Uložení vybraných hodnot
set /a soucetdopameti=%soucet%-%prog%
set pamet[%kolo%]=%soucetdopameti%,%prog%

rem Tah protihráče a oveření pro výhru
set /a soucet+=%random%*10/32768+1
if %soucet% lss 100 set /a kolo+=1 & goto hratrenovani

rem Odstranění zahraných hodnot z možných tahů
set /a a=0
:uceni
if %a% gtr %kolo% set /a i+=1 & goto trenovani
set pam=!pamet[%a%]!
if "%pam:~1,1%" == "," (
    set /a s=%pam:~0,1%
    if "%pam:~-2%" == "10" set /a p=10
    if "%pam:~-2%" neq "10" set /a p=%pam:~-1%
    ) else (
    set /a s=%pam:~0,2%
    if "%pam:~-2%" == "10" set /a p=10
    if "%pam:~-2%" neq "10" set /a p=%pam:~-1%
    )
set cislo%s%[%p%]=
set /a a+=1
goto uceni


:hra
rem Kontrola pro nevyplněné hodnoty
cls
echo Kontroluji pro vyplnene hodnoty...
for /l %%a in (0, 1, 99) do (
    set /a definovano=0
    for /l %%b in (1, 1, 10) do (
        if defined cislo%%a[%%b] set definovano=1
    )
    if %definovano% == 0 for /l %%b in (1, 1, 10) do (set /a cislo%%a[%%b]=%%b)
)

cls
echo Trenovani ukonceno!
choice /c AB /M "Stisknete A pro hrani hry, stisknete B pro vypis naucenych hodnot"
if %errorlevel% == 2 (
    for /l %%a in (0, 1, 99) do echo [%%a]   !cislo%%a[1]!;!cislo%%a[2]!;!cislo%%a[3]!;!cislo%%a[4]!;!cislo%%a[5]!;!cislo%%a[6]!;!cislo%%a[7]!;!cislo%%a[8]!;!cislo%%a[9]!;!cislo%%a[10]!
    pause
    goto hra
)

cls
echo Zacina hra...
set /a soucet=0

rem Vygenerování tahu pro hru s uživatelem
:genhra
set /a prog=%random%*10/32768+1
if not defined cislo%soucet%[%prog%] goto genhra
set /a soucet+=%prog%
if %soucet% geq 100 set /a vyherce=1 & goto konechry

echo Souperuv tah: %prog%
echo Aktualni soucet: %soucet%

rem Zadání tahu uživatele
:vastah
set /p tah=Vas tah: 
rem Ověření zadání
if "%tah%" == "" goto vastah
set /a a=%tah%
if %a% neq %tah% goto vastah
if %a% lss 1 goto vastah
if %a% gtr 10 goto vastah
set /a soucet+=%tah%
if %soucet% geq 100 set /a vyherce=2 & goto konechry

cls
echo.
goto :genhra

rem Konec hry
:konechry
cls
echo =========================================================
if %vyherce% == 1 (
    echo Konec hry, vyhercem se stava pocitac :^(
) else (
    echo Gratulujeme, vyhrali jste
)
echo =========================================================

rem Možnost o návrat zpět (když tu inteligenci trénujete 2 hodiny, tak abyste nepřišli o výsledek xD)
choice /c AN /M "Chcete se vratit zpet?"
if %errorlevel% == 1 goto hra

cls
echo Dekujeme, ze pouzivate tento program, i kdyz je to takovy odpad :D
echo Stisknete libovolnou klavesu pro konec...
pause > nul
exit /b 0