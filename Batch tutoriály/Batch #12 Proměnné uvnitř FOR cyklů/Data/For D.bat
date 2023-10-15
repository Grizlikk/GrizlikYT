@echo off
title FOR /D

for /d %%s in (s*) do (
    echo %%s
    cd %%s
    for /d %%p in (*) do (
        echo %%p
    )
    cd..
)


pause > nul
exit /b 0