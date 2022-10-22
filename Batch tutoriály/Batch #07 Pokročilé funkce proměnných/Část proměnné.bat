@echo off
color b
title Vypis casti promenne


set promenna=Serie tutorialu na BATCH! :D

echo Cela promenna:   %promenna%
echo.
rem Jedno číslo:

rem %promenna:~[číslo]% → Vypíše všechny znaky proměnné bez prvních [číslo] znaků
echo Promenna bez prvnich sesti znaku:   %promenna:~6%


rem %promenna:~[záporné číslo]% → Vypíše pouze posledních [záporné číslo] znaků
echo Poslednich devet znaku z promenne:   %promenna:~-9%



rem Dvě čísla:
echo.

rem %promenna:~[1. číslo],[2. číslo]% → Vypíše [2. číslo] znaků po [1. číslo]. znaku
echo Devet znaku po sestem znaku z promenne:   %promenna:~6,9%


rem %promenna:~[číslo],[záporné číslo]% → Vypíše všechny znaky proměnné bez prvních [číslo] znaků a bez posledních [záporné číslo] znaků
echo Promenna bez prvnich sesti znaku a bez poslednich deseti znaku:   %promenna:~6,-10%


rem %promenna:~[záporné číslo],[číslo]% → Vypíše [číslo] znaků po [záporné číslo]. znaku od konce
echo Sest znaku po devatem znaku od konce:   %promenna:~-9,6%


rem %promenna:~[1. záporné číslo],[2. záporné číslo]% → Vypíše [1. záporné číslo] znaků od konce, bez posledních [2. záporné číslo] znaků
echo Poslednich dvanact znaku z promenne bez poslednich tri znaku:   %promenna:~-12,-3%

pause > nul
exit