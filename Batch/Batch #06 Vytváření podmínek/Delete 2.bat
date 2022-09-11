@echo off
title Program
color e

set /p souhlas=Chcete smazat soubor.txt? [ano/ne]: 
if %souhlas% == ano (
    if exist Soubor.txt (del soubor.txt & echo Hotovo) else (echo Soubor.txt neexistuje)
    ) else (echo Ukoncovani programu)

pause