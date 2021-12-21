::Obávám se, že prolomit tohle heslo asi nebude moc složité :DDD
@echo off
color 4
:start
cls
echo Tato cast je chranena heslem, zadejte spravne heslo pro pokracovani
set /p heslo=Zadejte heslo: 
if %heslo% == 8165709524941 (cls
    color 2
    echo GRATULUJI!!! Podarilo se vam zadat spravne heslo!
    timeout /t 3 > nul
    start https://www.youtube.com/watch?v=iik25wqIuFo
    exit) else (cls
        echo SPATNE HESLO!!!
        echo SPATNE HESLO!!!
        echo SPATNE HESLO!!!
        timeout /t 2 > nul
        goto start
)