@echo off
title usebackq

rem "Text" = Název souboru
rem 'Text' = Prostě text
rem `Text` = Příkaz

for /f "usebackq" %%a in ("Webove stranky.txt") do (
    echo %%a
)

pause > nul
exit /b 0