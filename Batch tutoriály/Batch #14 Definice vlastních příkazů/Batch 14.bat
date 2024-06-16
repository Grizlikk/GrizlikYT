@echo off
setlocal enabledelayedexpansion

rem Spusteni funkce pro vypis bez odsazeni
call :Vypis "%cd%" -1
exit /b 0

:Vypis
rem Slozka Odsazeni

rem Odsazeni se pri kazdem pruchodu zvetsi o 1
set /a odsazeni = %~2 + 1
for /d %%d in ("%~1\*") do (
    rem Pri nalezu slozky program vypise veskry jeji obsah s odsazenim
    call :VypsatSlozku "%%d" %odsazeni%
    rem Pro kazdou nalezenou slozku se funkce zavola znovu pro vypis obsahu (rekurze)
    call :Vypis "%%d" %odsazeni%
)
goto :eof


:VypsatSlozku
rem Slozka Odsazeni

rem Vygenerovani mezery pro odsazeni
set odsazeni=
for /l %%i in (1, 1, %~2) do (
    set odsazeni=     !odsazeni!
)
set slozka=%~1

rem Precteni nazvu aktualni slozky z jeji kompletni cesty
:najitNazevSlozky
for /f "tokens=1* delims=\" %%a in ("%slozka%") do (
    if "%%b" == "" (
        set slozka=%%a
    ) else (
        set slozka=%%b
        goto :najitNazevSlozky
    )
)
rem Vypis slozky s odsazenim
echo %odsazeni%%slozka%

rem Vypis vsech souboru ve slozce
cd %~1
for %%s in (*) do (
    echo %odsazeni%     %%s
)
goto :eof