@echo off
color 9
title y = 9x^4 + 4x^3 - 5x^2 + 48x - 63
set /a x=1
rem y = 9x^4 + 4x^3 - 5x^2 + 48x - 63
:a
if %x% gtr 2500 goto end
set /a y=9*%x%*%x%*%x%*%x%+4*%x%*%x%*%x%-5*%x%*%x%+48%x%-63
echo [%x% ; %y%]
set /a x=%x%+1
goto a

:end
echo.
echo HOTOVO!!!
pause > nul
exit