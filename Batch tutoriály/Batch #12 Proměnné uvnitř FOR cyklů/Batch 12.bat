@echo off
title Batch 12
color b

rem Nastavení podpory pro české znaky
chcp 65001 > nul

rem Definice proměnných
set /a celkemRadky = 0
set /a celkemNalezeneSoubory = 0
set /a celkemSoubory = 0
rem Jednu složku je nutné odečíst, protože původní složka "Data" se nepočítá
set /a celkemSlozky = -1
set /a pocetHledanychSouboru = 0

rem Kontrola pro existenci seznamu
if not exist Seznam.txt echo Soubor "Seznam.txt" nebyl nalezen! & pause & exit /b 2

rem Kontrola pro existenci složky s daty
if not exist Data echo Slozka "Data" nebyla nalezena! & pause & exit /b 3

rem Vyhledání počtu hledaných souborů
for /f %%a in (Seznam.txt) do (
    set /a pocetHledanychSouboru += 1
)

rem Kontrola pro prázdný soubor seznamu
if %pocetHledanychSouboru% == 0 echo Soubor "Seznam.txt" je prazdny! & pause & exit /b 2

cd Data
rem Procházení složek 3 složky do hloubky, v každé složce se spustí funkce "NajdiSoubory"
call :NajdiSoubory ../Seznam.txt
for /d %%a in (*) do (
    cd %%a
    call :NajdiSoubory ../../Seznam.txt
    for /d %%b in (*) do (
        cd %%b
        call :NajdiSoubory ../../../Seznam.txt
        for /d %%c in (*) do (
            cd %%c
            call :NajdiSoubory ../../../../Seznam.txt
            cd..
        )
        cd..
    )
    cd..
)
cd..

echo ----------------------------------------------------
echo.
echo Celkovy pocet radku: %celkemRadky%
echo Celkovy pocet nalezenych souboru: %celkemNalezeneSoubory% z %pocetHledanychSouboru%
echo Celkovy pocet prohledanych souboru: %celkemSoubory%
echo Celkovy pocet prohledanych slozek: %celkemSlozky%
echo.

pause>nul
exit /b 0


rem Funkce pro výpočet počtu řádků v souboru
:PocetRadku
rem Soubor

echo Soubor: %~1
set /a radky = 0

rem Pro každý řádek se přičte 1 k celkovému počtu řádků
for /f "usebackq" %%f in ("%~1") do (
    set /a radky+=1
)

rem Výpis počtu řádků
echo Pocet radku: %radky%
echo.

rem Započítání k celkovému počtu řádků a nalezených souborů
set /a celkemNalezeneSoubory += 1
set /a celkemRadky += %radky%
goto :eof


rem Funkce pro prohledání všech souborů ve složce a detekci hledaných souborů podle "Seznam.txt"
:NajdiSoubory
rem Cesta k seznamu souborů

set /a nalezeno = 0

for %%d in (*) do (
    for /f "tokens=*" %%s in (%~1) do (
        if "%%s" == "%%d" (
            rem Pro každý hledaný soubor se spustí funkce "PocetRadku"
            call :PocetRadku "%%d"
            set /a nalezeno +=1
        )
    )
    rem Pro každý soubor se přičte jeden prohledávaný soubor
    set /a celkemSoubory += 1
)
rem Pro každou prohledanou složku se tato funkce "NajdiSoubory" spustí právě jednou
set /a celkemSlozky += 1
goto :eof