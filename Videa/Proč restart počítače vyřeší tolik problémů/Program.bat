@echo off
color 9

::Začátek programu
echo Tohle je program, ktery ke spravnemu fungovani potrebuje svuj pomocny soubor.
echo.
pause

::Vytvoření "důležitého" souboru
cls
echo Probiha vytvareni pomocneho souboru...
::Ano, během tohoto čekání program nic nedělá, vytvoření souboru netrvá tak dlouho :)
timeout /t 2 > nul
echo Tento soubor je kriticky důležitý pro správne fungování programu. V žádném případě nedoporučujeme tento soubor mazat!!! > "Dulezity soubor.txt"
cls
echo Pomocny soubor byl vytvoren, stisknete libovolnou klavesu pro pokracovani...
echo.
pause

::Pokud soubor existuje, tak to vypíše tento text
cls
if exist "Dulezity soubor.txt" (
    color 6
    echo Soubor uspesne nalezen! Program nyni muze spravne fungovat :D
    echo.
    pause
    del "Dulezity soubor.txt"
    exit
    )
::A pokud soubor neexistuje, tak to vypíše tento text
if not exist "Dulezity soubor.txt" (
    color 4
    echo ERROR!!! Potrebny soubor nebyl nalezen, program bez nej nedovede pokracovat
    echo.
    pause
    exit
    )

echo Muzete mi vysvetlit, jak se vam podarilo dostat do teto faze???
echo Bez upravy kodu souboru by to melo byt nemozne... :D
pause
exit