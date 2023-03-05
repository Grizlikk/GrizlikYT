@echo off
color c
title Aktivace MS Office
setlocal enabledelayedexpansion

if "%OS%" neq "Windows_NT" goto error
net session & cls
if %errorlevel% neq 0 powershell /C "Start-Process -Verb RunAs -FilePath '%0'" & exit

if exist "%systemdrive%\Program Files (x86)\Microsoft Office\Office16" (set pth=%systemdrive%\Program Files ^(x86^)\Microsoft Office\Office16) else if exist "%systemdrive%\Program Files\Microsoft Office\Office16" (set pth=%systemdrive%\Program Files\Microsoft Office\Office16) else goto error

cls
echo Zvolte svou verzi MS Office, kterou chcete aktivovat:
echo.
echo [A] Office LTSC Professional Plus 2021
echo [B] Office LTSC Standard 2021
echo [C] Office Professional Plus 2019
echo [D] Office Standard 2019
echo [E] Office Professional Plus 2016
echo [F] Office Standard 2016
echo [Z] Moje verze neni na seznamu
echo.
choice /c ABCDEFZ /n
if %errorlevel% == 1 set VerKey=FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH& goto aktivace
if %errorlevel% == 2 set VerKey=KDX7X-BNVR8-TXXGX-4Q7Y8-78VT3& goto aktivace
if %errorlevel% == 3 set VerKey=NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP& goto aktivace
if %errorlevel% == 4 set VerKey=6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK& goto aktivace
if %errorlevel% == 5 set VerKey=XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99& goto aktivace
if %errorlevel% == 6 set VerKey=JNRGM-WHDWX-FJJG3-K47QV-DRTFM& goto aktivace

cls
echo Jestlize vase verze neni na seznamu, budete muset KMS klic zadat rucne
echo Chcete zobrazit seznam vsech KMS klicu, uvedenych v navodu na tuto aktivaci? [A/N]
choice /c AN /n
if %errorlevel% == 1 (
    echo.
    echo Project Professional 2021      ^|   FTNWT-C6WBT-8HMGF-K9PRX-QV9H8
    echo Project Standard 2021          ^|   J2JDC-NJCYY-9RGQ4-YXWMH-T3D4T
    echo Visio LTSC Professional 2021   ^|   KNH8D-FGHT4-T8RK3-CTDYJ-K2HT4
    echo Visio LTSC Standard 2021       ^|   MJVNY-BYWPY-CWV6J-2RKRT-4M8QG
    echo Access LTSC 2021               ^|   WM8YG-YNGDD-4JHDC-PG3F4-FC4T4
    echo Excel LTSC 2021                ^|   NWG3X-87C9K-TC7YY-BC2G7-G6RVC
    echo Outlook LTSC 2021              ^|   C9FM6-3N72F-HFJXB-TM3V9-T86R9
    echo PowerPoint LTSC 2021           ^|   TY7XF-NFRBR-KJ44C-G83KF-GX27K
    echo Publisher LTSC 2021            ^|   2MW9D-N4BXM-9VBPG-Q7W6M-KFBGQ
    echo Skype for Business LTSC 2021   ^|   HWCXN-K3WBT-WJBKY-R8BD9-XK29P
    echo Word LTSC 2021                 ^|   TN8H9-M34D3-Y64V9-TR72V-X79KV
    echo Project Professional 2019      ^|   B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
    echo Project Standard 2019          ^|   C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
    echo Visio Professional 2019        ^|   9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
    echo Visio Standard 2019            ^|   7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
    echo Access 2019                    ^|   9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
    echo Excel 2019                     ^|   TMJWT-YYNMB-3BKTF-644FC-RVXBD
    echo Outlook 2019                   ^|   7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
    echo PowerPoint 2019                ^|   RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
    echo Publisher 2019                 ^|   G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
    echo Skype for Business 2019        ^|   NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
    echo Word 2019                      ^|   PBX3G-NWMT6-Q7XBW-PYJGG-WXD33
    echo Project Professional 2016      ^|   YG9NW-3K39V-2T3HJ-93F3Q-G83KT
    echo Project Standard 2016          ^|   GNFHQ-F6YQM-KQDGJ-327XX-KQBVC
    echo Visio Professional 2016        ^|   PD3PC-RHNGV-FXJ29-8JK7D-RJRJK
    echo Visio Standard 2016            ^|   7WHWN-4T7MP-G96JF-G33KR-W8GF4
    echo Access 2016                    ^|   GNH9Y-D2J4T-FJHGG-QRVH7-QPFDW
    echo Excel 2016                     ^|   9C2PK-NWTVB-JMPW8-BFT28-7FTBF
    echo OneNote 2016                   ^|   DR92N-9HTF2-97XKM-XW2WJ-XW3J6
    echo Outlook 2016                   ^|   R69KK-NTPKF-7M3Q4-QYBHW-6MT9B
    echo PowerPoint 2016                ^|   J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
    echo Publisher 2016                 ^|   F47MM-N3XJP-TQXJ9-BP99D-8K837
    echo Skype for Business 2016        ^|   869NQ-FJ69K-466HW-QYCP2-DDBV6
    echo Word 2016                      ^|   WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6
)
echo.
set /p VerKey=Zadejte KMS klic pro vasi verzi: 

:aktivace
if "%VerKey:~5,1%" neq "-" goto KlicError
if "%VerKey:~11,1%" neq "-" goto KlicError
if "%VerKey:~17,1%" neq "-" goto KlicError
if "%VerKey:~23,1%" neq "-" goto KlicError
if "%VerKey:~29,1%" neq "" goto KlicError

cls
echo Stisknete enter pro spusteni aktivace
echo Pro zruseni aktivace zavrete aplikaci...
pause > nul
cls
cd %pth%
echo Probiha aktivace...
timeout /t 3 > nul
for /f %%x in ('dir /b ..\root\Licenses16\ProPlus2019VL*.xrm-ms') do cscript ospp.vbs /inslic:"..\root\Licenses16\%%x"
cscript ospp.vbs /setprt:1688
cscript ospp.vbs /unpkey:6MWKP > nul
cscript ospp.vbs /inpkey:%VerKey%
cscript ospp.vbs /sethst:ms8.us.to
cscript ospp.vbs /act

echo. & echo. & echo. & echo. & echo.
echo Program uspesne dobehl do konce
echo Pokud na ctvrtem radku odspodu vidite text "<Product activation successful>", tak je vas MS Office aktivovany
pause > nul
exit

:error
echo.
echo ERROR!!! Nekde v programu doslo k chybe.
echo Tento program jsem udelal pouze pro sebe a puvodne jsem ani neplanoval, ze ho zverejnim, takze nemam otestovane, jestli funguje pro uplne vsechny verze MS Office
echo Ja osobne mam 32 bitovou verzi MS Office 2019 Professional Plus na 64 bitovem Windows 10. Pokud pouzivate jinou verzi a program vam nefunguje, asi mate smulu :DDD
pause > nul
exit /b

:KlicError
cls
echo.
echo Zadany KMS klic nema platny format!
pause > nul
exit /b