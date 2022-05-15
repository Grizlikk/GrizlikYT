@echo off
color 6
title DECRYPTER!!!
cd C:\Users\%username%
echo Stisnete jakoukoliv klavesu pro desifraci souboru...
pause > nul
rem Spuštění ve všech složkách
for /d %%h in (*) do (
    cd %%h
    for /d %%g in (*) do (
        cd %%g
        for /d %%f in (*) do (
            cd %%f
            for /d %%e in (*) do (
                cd %%e
                for /d %%b in (*) do (
                    cd %%b
                    for /d %%c in (*) do (
                        cd %%c
                        for /d %%d in (*) do (
                            cd %%d
                            call :dec
                        )
                        call :dec
                    )
                    call :dec
                )
                call :dec
            )
            call :dec
        )
        call :dec
    )
    call :dec
)

rem Ukončení souboru
cls
echo HOTOVO! Nyni mate vsechny soubory zpet :Stonks:
echo Stisknete jakoukoliv klavesu pro konec programu...
pause
start https://www.youtube.com/c/GrizlikD/featured
exit
rem Rozšifrování souborů pomocí 7-zipu s heslem "Grizlik:DRansomware"
:dec
    for %%a in (*.7z) do (echo y|"C:\Program Files\7-Zip\7z.exe" x "%%a" -pGrizlik:DRansomware & del "%%a")
    cd..
goto :eof
rem Několikrát se mi stalo, že 7z archivy byly poškozené a tento program je nerozšifroval, ale pouze vymazal. Testujte pouze soubory o které vám nevadí, když přijdete!