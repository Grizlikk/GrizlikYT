@echo off
title Lokalni a globalni promenne

set /a a=5
echo %a%

SETLOCAL
set /a a=10
set /a b=15
echo %a%
ENDLOCAL & set /a c=%b%

echo %a%
echo %b%
echo %c%

pause > nul
exit /b 0