@echo off
color 6

::Začátek programu
echo Vitejte v programu generator nahodnych cisel 3001!!!
echo.
echo Tento program vezme nahodne cislo, vynasobi ho 100 a pote ho vydeli nahodnym cislem vynasobenym 3
echo.
pause

::Generátor náhodného čísla se záměrnou chybou
cls
set /a cislo = (%random% * 100) / (%random% * 3)
echo Vase nahodne cislo je %cislo%
echo.
echo.
pause
exit
::PS: Pokud bych do programu napsal pouze "echo %random%", tak by to fungovalo taky, program je pouze na vysvěltení, proto je tento generátor až zbytečně složitě udělaný