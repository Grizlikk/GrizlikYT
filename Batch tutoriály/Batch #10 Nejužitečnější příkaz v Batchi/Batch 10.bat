@echo off
title Vyhledavani souboru
color b

:start
rem Zadání složky a názvu souboru pro vyhledávání
set /p cesta=Zadejte cestu ke slozce: 
if not exist %cesta% cls & echo Neplatne zadani! & goto start
set /p soubor=Zadejte nazev souboru nebo pripony pro vyhledani: 

rem Úprava formátu dat
if "%soubor%" == "" set soubor=*

rem Spuštění vyhledávání souboru
cls
forfiles /s /p %cesta% /m %soubor% /c "cmd /c echo Soubor byl nalezen: @path"

rem Pokud nebyly nalezeny žádné soubory, asi nebyl název souboru zcela přesný
if %errorlevel% neq 0 cls & forfiles /s /p %cesta% /m *%soubor% /c "cmd /c echo Soubor byl nalezen: @path"

rem Pokud nebyly nalezeny žádné soubory, asi nebyl název souboru zcela přesný
if %errorlevel% neq 0 cls & forfiles /s /p %cesta% /m *%soubor%* /c "cmd /c echo Soubor byl nalezen: @path"

if %errorlevel% neq 0 (
    cls
    echo Nebyly nalezeny zadne soubory na zaklade zanadych filtru
    goto konec
)

rem Ukončení programu
echo.
echo Program uspesne dobehl do konce :D
echo.
choice /c AN /m "Chcete vyhledat dalsi soubory? "
if %errorlevel% == 1 cls & goto start
cls
:konec
echo Stisknete libovolnou klavesu pro konec...

pause > nul
exit /b 0