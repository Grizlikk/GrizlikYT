@echo of
title Podminky

set /p promenna=Zadejte: 

if a%promenna% == aText echo Ahoj
if "%promenna%" == "Text" echo Ahoj

if %random% == 1000 echo Tisic

pause > nul
exit /b 0