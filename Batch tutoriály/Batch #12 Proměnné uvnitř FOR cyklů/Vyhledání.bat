@echo off
title Vyhledani

set /p hodnota=Zadejte hodnotu pro vyhledani: 
cd Soubory

set /a celkemSouboru = 0

cls
for %%s in (*) do (
    set /a celkemSouboru += 1
    for /f "usebackq" %%a in ("%%s") do (
        if %%a == %hodnota% (
            echo Hodnota %hodnota% byla nalezena v souboru %%s
            goto konec
        )
    )
)

echo Hodnota %hodnota% nebyla nalezena.

:konec
echo Celkem bylo prohledano %celkemSouboru% souboru
pause > nul
exit /b 0