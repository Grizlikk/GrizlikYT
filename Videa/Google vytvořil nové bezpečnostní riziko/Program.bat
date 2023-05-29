@echo off
cd /d C:\Users\Public
echo x=MsgBox("Prave byl spusten spustitelny soubor :D", 0+16, "POZOR!!!") > error.vbs
timeout /t 0 > nul
error.vbs
timeout /t 0 > nul
del error.vbs
exit