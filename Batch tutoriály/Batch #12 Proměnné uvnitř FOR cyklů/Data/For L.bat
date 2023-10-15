@echo off
title FOR /L

for /l %%i in (20, -1, 0) do (
    echo %%i
)


pause > nul
exit /b 0