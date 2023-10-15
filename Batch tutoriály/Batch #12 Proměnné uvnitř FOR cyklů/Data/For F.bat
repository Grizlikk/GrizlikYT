@echo off
title FOR /F

for /f %%a in ('ping google.com') do (
    echo %%a
    timeout /t 1 > nul
)


pause > nul
exit /b 0