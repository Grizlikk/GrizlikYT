@echo off
title Opakovani

set /a a=0
:reset
if %a%==10 goto exit

echo %a%
set /a a+=1

goto reset

:exit
pause