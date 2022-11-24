@echo off
title :DDDDD
color 6

call :text "give you up"
call :text "let you down"
call :text "run around and desert you"
call :text "make you cry"
call :text "say goodbye"
call :text "tell a lie and hurt you."

timeout /t 3 > nul
echo :DDDDD
start https://youtu.be/dQw4w9WgXcQ
pause > nul
exit

:text
    echo Never gonna %~1
    timeout /t 1 > nul
goto :eof

