@echo off
title Parametry souboru

echo Zacatek programu

if "%1" == "/vypis" (
    echo Tento vypis byl spusten pomoci parametru
    ) else (
        echo Parametr "/vypis" nebyl zadan
    )

echo Konec programu

pause > nul
exit /b 0