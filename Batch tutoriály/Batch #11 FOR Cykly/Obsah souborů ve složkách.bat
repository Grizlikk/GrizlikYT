@echo off
title Obsah souboru ve slozkach

for /d %%s in (*) do (
    cd %%s
    for %%f in (*) do (
        echo Soubor: %%f
        echo.
        type %%f
        echo.
        echo.
        echo ===============
        echo.
    )
    cd..
)


pause > nul
exit /b 0