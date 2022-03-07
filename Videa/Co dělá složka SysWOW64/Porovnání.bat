@echo off
color 3
c:
cd c:\Windows\syswow64

::Pomocná složka s počtem stejných souborů, pokud by někdo na ploše už  měl složku s názvem "stejné", program se ukončí
if exist "c:\users\%username%\desktop\stejne" rd "c:\users\%username%\desktop\stejne" /q > nul
if not exist "c:\users\%username%\desktop\stejne" md "c:\users\%username%\desktop\stejne" & goto next
exit

:next
echo Probiha porovnavani...
::V pomocné složce se vytvoří soubory se stejnými názvemy .txt
forfiles /c "cmd /c if @isdir==FALSE if exist c:\windows\system32\@file echo :D > c:\users\%username%\desktop\stejne\@fname.txt"

cls
echo HOTOVO!
pause
exit