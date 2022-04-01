@echo off
for %%i in (0, 1, 2, 3, 4) do (
    echo.
    echo %0 ^| %0
    timeout /t %%i > nul
)
start cmd /c "taskkill /f /im wordpad.exe > nul"
exit