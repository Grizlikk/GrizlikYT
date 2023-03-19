@echo off
title Kopirovani souboru
color e

:start
set /p zdroj=Zadejte zdrojovou slozku: 
if not exist %zdroj% cls & echo ERROR & goto start

set /p cil=Zadejte cilovou slozku: 
if not exist %cil% md %cil%

forfiles /p %zdroj% /c "cmd /c if @isdir==FALSE copy @file %cil%"

cls
echo HOTOVO
pause > nul
exit 0