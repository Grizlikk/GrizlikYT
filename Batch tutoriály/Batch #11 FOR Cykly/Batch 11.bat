@echo off
color b
title Batch 11

rem Ověření, jestli existuje složka s databází
if not exist Databaze echo Slozka databaze nebyla nalezena! & pause & exit /b 2

rem Vyhledání všech složek
cd Databaze
for /d %%f in (*) do (
    cd %%f
    rem Přečtení všech souborů
    for %%s in (*) do (
        rem Výpis názvu souboru
        echo ===============
        echo %%s
        echo ===============
        echo.

        rem Přečtení všech řádků souborů
        for /f "tokens=1,2,3,* delims=;" %%a in (%%s) do (
            echo Jmeno: %%a     Prijmeni: %%b     Telefon: %%c
        )
        echo.
    )
    cd..
)

pause > nul
exit /b 0