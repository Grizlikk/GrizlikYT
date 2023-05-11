@echo off
title Pocet souboru

set /a pocet=0
for %%s in (*) do (
    set /a pocet+=1
)

echo Ve slozce je %pocet% souboru

pause > nul
exit /b 0