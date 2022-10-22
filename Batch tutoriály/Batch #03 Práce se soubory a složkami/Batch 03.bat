@echo off
cd /
cd "Program Files"
dir > C:\Users\%username%\Desktop\Seznam.txt
cd..
cd "Program Files (x86)"
dir >> C:\Users\%username%\Desktop\Seznam.txt
cd..
cd "Users"
dir >> C:\Users\%username%\Desktop\Seznam.txt
cd..
cd "Windows"
dir >> C:\Users\%username%\Desktop\Seznam.txt
cd C:\Users\%username%\Desktop
md "Kontrolni slozka"
move Seznam.txt "Kontrolni slozka"
cls
cd "Kontrolni slozka"
echo Hotovo! Stisknete jakoukoliv klavesu pro spusteni seznamu...
pause > nul
start notepad Seznam.txt