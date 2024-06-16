@echo off
:loop
tasklist | find "HandBrake.exe"
if %errorlevel% neq 0 (
    shutdown /r /t 60
)
timeout /t 30
goto loop