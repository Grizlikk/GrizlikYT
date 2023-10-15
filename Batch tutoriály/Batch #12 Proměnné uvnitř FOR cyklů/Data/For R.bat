@echo off
title FOR /R

for /r %%a in (*) do (
    echo %%a
)


pause > nul
exit /b 0