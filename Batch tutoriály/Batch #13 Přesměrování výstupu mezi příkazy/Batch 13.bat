@echo off
title Batch 13
setlocal enabledelayedexpansion

rem Spustí se příkaz "systeminfo" a v něm se najde text "Microsoft Windows"
rem Bylo by možné také hledat třeba "OS Name:", ale to se u starších Windowsů vypsat nemusí, "Microsoft Windows" je tedy kompatibilnější

for /f "tokens=*" %%a in ('systeminfo ^| find "Microsoft Windows"') do (
    rem Celý řádek obsahující text "OS Name:" se uloží do proměnné "informace"
    set informace=%%a
)

rem Pomocná proměnná pro výsledné oddělení vypsaného textu
set oddeleni====================

rem Název OS je "Windows ..."
rem Program tedy bude číst text od konce, dokud nenarazí na "Windows" nebo nepřečetl 100 znaků
for /l %%i in (-1, -1, -100) do (
    rem Uložení řádku
    set radek=!informace:~%%i!
    set oddeleni=!oddeleni!=

    rem Kontrola, jestli prvních 7 znaků je "Windows"
    if "!radek:~0,7!" == "Windows" (
        set verze=!radek!
        goto koneccyklu
    )
)
:koneccyklu

rem Koncový výpis
echo %oddeleni%
echo Aktualne pouzivate %verze%
echo %oddeleni%

pause > nul
exit /b 0