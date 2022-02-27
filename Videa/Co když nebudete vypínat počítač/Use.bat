@echo off
color 4
:a
cls
echo Probiha startovani...
for /l %%i in (1, 1, 75) do (start wordpad.exe)
taskkill /im wordpad.exe
cls
echo Restart...
timeout /t 2 > nul
goto a