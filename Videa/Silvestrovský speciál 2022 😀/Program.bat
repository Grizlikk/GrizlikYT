@echo off
set /a tm=%time:~0,2%
if %tm% == 23 goto h23
if %tm% == 0 timeout /t 300 & goto h0

rem Čekání na 22 hodin
:res
if %time:~0,2% == 22 goto h22
timeout /t 3000
goto res

rem 22 hodin, čekání na 23 hodin
:h22
timeout /t 30
if %time:~0,2% == 23 goto h23
goto h22

rem 23 hodin
:h23
rem Soubory errorů
if not exist "error0.vbs" echo x=MsgBox("Uz je po 23:00!", 0+16, "POZOR!!!") > error0.vbs
if not exist "error1.vbs" echo x=MsgBox("Uz je po 23:00!", 0+48, "POZOR!!!") > error1.vbs

rem Spouštění errorů
for /l %%i in (1, 1, 3) do (
    start error0.vbs
    timeout /t 60
    start error1.vbs
    timeout /t 60
)
for /l %%i in (1, 1, 4) do (
    start error0.vbs
    timeout /t 30
    start error1.vbs
    timeout /t 30
)
for /l %%i in (1, 1, 20) do (
    start error0.vbs
    timeout /t 15
    start error1.vbs
    timeout /t 15
)
start cmd.exe
for /l %%i in (1, 1, 30) do (
    start error0.vbs
    timeout /t 10
    start error1.vbs
    timeout /t 10
)
start cmd.exe
for /l %%i in (1, 1, 180) do (
    start error0.vbs
    timeout /t 5
    start error1.vbs
    timeout /t 5
    if %%i == 50 start cmd.exe
    if %%i == 150 start cmd.exe
)

rem 0 hodin
:h0
for /l %%i in (1, 1, 600) do (
    start error0.vbs
    timeout /t 3
    start error1.vbs
    timeout /t 3
)
for /l %%i in (1, 1, 10) do (
    start cmd.exe
)
timeout /t 300

rem Bez jakékoliv reakce se program v 1 hodinu ráno ukončí
taskkill /im wscript.exe
taskkill /im cmd.exe