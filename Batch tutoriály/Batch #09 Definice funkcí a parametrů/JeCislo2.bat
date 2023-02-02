SETLOCAL
set /a a = %1
if "%1" neq "%a%" cls & echo Neplatne zadani! & echo. & call "Lokalni promenne externi"
ENDLOCAL
goto :eof