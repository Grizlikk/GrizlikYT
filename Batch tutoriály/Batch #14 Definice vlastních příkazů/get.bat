@echo off
winget search %1
echo Opravdu chcete nainstalovat: %1 [A/N]?
choice /c AN /n
if %errorlevel% == 1 winget install %1