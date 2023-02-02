set /a a = %1
if "%1" neq "%a%" cls & echo Neplatne zadani! & echo. & call "Overeni pro cislo"

goto :eof