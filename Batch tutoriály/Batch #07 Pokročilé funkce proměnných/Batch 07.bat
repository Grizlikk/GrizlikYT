@echo off
color b
title Vypocet casu

:start
rem Zadání údajů
echo Vypocet doby k urcitemu casovemu udaji
echo.
set /p cas=Zadejte casovy udaj: 

rem Pokud zadaný čas obsahuje na 2. pozici dvojtečku, hodiny jsou jednociferné, pokud ne, hodiny jsou dvojciferné
if %cas:~1,1%==: (
    set /a hodiny_vysl = %cas:~0,1%
    
    rem Pokud jsou hodiny jednociferné, minuty budou o znak dříve
    if %cas:~2,1% == 0 (set /a minuty_vysl=%cas:~3,1%) else (set /a minuty_vysl=%cas:~2,2%)

    ) else (
        set /a hodiny_vysl = %cas:~0,2%

        rem Pokud jsou hodiny dvojciferné, minuty budou stejně jako v proměnné %time%
        if %cas:~3,1% == 0 (set /a minuty_vysl=%cas:~4,1%) else (set /a minuty_vysl=%cas:~3,2%)
    )

rem Ošetření pro platné hodnoty
if %hodiny_vysl% gtr 23 echo Neplatna hodnota! & pause & cls & goto start
if %minuty_vysl% gtr 59 echo Neplatna hodnota! & pause & cls & goto start


rem Pro čas vytvářím samostatnou proměnnou, protože během zpracování dat by se aktuální čas mohl změnit
set tm=%time%


rem Pokud jsou hodiny jednociferné, počet znaků ne nezmění a před čas se přidá prázdný znak, který se automaticky odstraní, když místo příkazu "set" použiji "set /a"
rem Aktuální počet hodin tedy vždy odpovídá prvním dvěma cifrám z proměnné %time%
set /a hodiny_akt=%tm:~0,2%

rem Pokud je ihned za dvojtečkou číslo 0, minuty jsou jednociferné a tedy počet minut bude až to číslo za tou nulou (protože např. "set /a minuty=08" by nefungovalo)
rem Pokud číslo po dvojtečce není 0, minuty musí být dvojciferné, takže se uloží 2 číslice po dvojtečce
if %tm:~3,1% == 0 (set /a minuty_akt=%tm:~4,1%) else (set /a minuty_akt=%tm:~3,2%)


set /a Vysledek_Hodiny = %hodiny_vysl% - %hodiny_akt%
set /a Vysledek_Minuty = %minuty_vysl% - %minuty_akt%


rem Přepočet na platný časový údaj v případě záporných minut nebo záporných hodin
if %Vysledek_Minuty% lss 0 set /a Vysledek_Hodiny -= 1 & set /a Vysledek_Minuty += 60
if %Vysledek_Hodiny% lss 0 set /a Vysledek_Hodiny += 24

rem Uložení aktuálního času, pokud jsou minuty jednociferné, musí se před ně doplnit nula
if %tm:~3,1% == 0 (set aktualni_cas=%hodiny_akt%:0%minuty_akt%) else (set aktualni_cas=%hodiny_akt%:%minuty_akt%)

rem Vygenerování výpisového textu ve správném češtinářském tvaru
if %Vysledek_Hodiny% equ 1 set gramatika_hodiny=hodinu
if %Vysledek_Hodiny% gtr 1 set gramatika_hodiny=hodiny
if %Vysledek_Hodiny% gtr 4 set gramatika_hodiny=hodin

set gramatika_minuty=minut
if %Vysledek_Minuty% equ 1 set gramatika_minuty=minutu
if %Vysledek_Minuty% gtr 1 set gramatika_minuty=minuty
if %Vysledek_Minuty% gtr 4 set gramatika_minuty=minut

rem Koncový výpis
echo.
echo.
if %Vysledek_Hodiny% gtr 0 (
    echo Od aktualinho casu %aktualni_cas% bude cas %cas% nejdrive za %Vysledek_Hodiny% %gramatika_hodiny% a %Vysledek_Minuty% %gramatika_minuty%
    ) else if %aktualni_cas% == %cas% (
        echo Cas %aktualni_cas% je prave ted
    ) else (echo Od aktualinho casu %aktualni_cas% bude cas %cas% nejdrive za %Vysledek_Minuty% %gramatika_minuty%)
pause > nul
exit