@echo off
color 6
title Aktivace MS Office
setlocal enabledelayedexpansion

if "%OS%" neq "Windows_NT" goto VerError
net session & cls
echo Probiha nacitani programu...
if %errorlevel% neq 0 powershell /C "Start-Process -Verb RunAs -FilePath '%0'" & exit

if exist "%systemdrive%\Program Files (x86)\Microsoft Office\Office16" (set pth=%systemdrive%\Program Files ^(x86^)\Microsoft Office\Office16) else if exist "%systemdrive%\Program Files\Microsoft Office\Office16" (set pth=%systemdrive%\Program Files\Microsoft Office\Office16) else goto PathError

cls
echo Zvolte svou verzi MS Office, kterou chcete aktivovat:
echo.
echo [A] Office LTSC Professional Plus 2021
echo [B] Office LTSC Standard 2021
echo [C] Office Professional Plus 2019
echo [D] Office Standard 2019
echo [Z] Moje verze neni na seznamu
echo.
choice /c ABCDZ /n
if %errorlevel% == 1 set VerKey=FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH&set Licence=ProPlus2021& goto aktivace
if %errorlevel% == 2 set VerKey=KDX7X-BNVR8-TXXGX-4Q7Y8-78VT3&set Licence=Standard2021& goto aktivace
if %errorlevel% == 3 set VerKey=NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP&set Licence=ProPlus2019& goto aktivace
if %errorlevel% == 4 set VerKey=JNRGM-WHDWX-FJJG3-K47QV-DRTFM&set Licence=Standard2019& goto aktivace

cls
echo Omlouvam se, ale tato verze aktivatoru nepodporuje jine, nez vyse uvedene verze MS Office
echo Muzete si vyhledat KMS klic pro vasi konketni verzi a upravit kod tohoto programu s vami zadanym klicem
pause > nul
exit /b 0

:aktivace
if "%VerKey:~5,1%" neq "-" goto KlicError
if "%VerKey:~11,1%" neq "-" goto KlicError
if "%VerKey:~17,1%" neq "-" goto KlicError
if "%VerKey:~23,1%" neq "-" goto KlicError
if "%VerKey:~29,1%" neq "" goto KlicError

cls
echo Prejete si aktivovat MS Office podle zvoleneho KMS klice [A/N]?
choice /c AN /n
if %errorlevel% == 2 exit /b 1

cls
cd %pth%
echo Probiha aktivace...
timeout /t 2 /nobreak > nul

cscript ospp.vbs /rearm
cscript ospp.vbs /actype:2
for /f %%x in ('dir /b ..\root\Licenses16\%Licence%VL*.xrm-ms') do cscript ospp.vbs /inslic:"..\root\Licenses16\%%x"
cscript ospp.vbs /inpkey:%VerKey%
for /l %%k in (1, 1, 40) do (
    echo.
    echo [PRUCHOD: %%k]
    echo.
    if %%k == 1 set KMS=kms.digiboy.ir
    if %%k == 2 set KMS=hq1.chinancce.com
    if %%k == 3 set KMS=54.223.212.31
    if %%k == 4 set KMS=kms.cnlic.com
    if %%k == 5 set KMS=kms.chinancce.com
    if %%k == 6 set KMS=kms.ddns.net
    if %%k == 7 set KMS=franklv.ddns.net
    if %%k == 8 set KMS=k.zpale.com
    if %%k == 9 set KMS=m.zpale.com
    if %%k == 10 set KMS=mvg.zpale.com
    if %%k == 11 set KMS=kms.shuax.com
    if %%k == 12 set KMS=kensol263.imwork.net:1688
    if %%k == 13 set KMS=xykz.f3322.org
    if %%k == 14 set KMS=kms789.com
    if %%k == 15 set KMS=dimanyakms.sytes.net:1688
    if %%k == 16 set KMS=kms.03k.org:1688
    if %%k == 17 set KMS=kms.lotro.cc
    if %%k == 18 set KMS=mhd.kmdns.net110
    if %%k == 19 set KMS=noip.me
    if %%k == 20 set KMS=45.78.3.223
    if %%k == 21 set KMS=kms.didichuxing.coms
    if %%k == 22 set KMS=zh.us.to
    if %%k == 23 set KMS=toxykz.f3322.org
    if %%k == 24 set KMS=192.168.2.81.2.7.0
    if %%k == 25 set KMS=kms.guowaifuli.com
    if %%k == 26 set KMS=106.186.25.2393
    if %%k == 27 set KMS=rss.vicp.net:20439
    if %%k == 28 set KMS=122.226.152.230
    if %%k == 29 set KMS=222.76.251.188
    if %%k == 30 set KMS=annychen.pw
    if %%k == 31 set KMS=heu168.6655.la
    if %%k == 32 set KMS=kms.aglc.cc
    if %%k == 33 set KMS=kms.landiannews.com
    if %%k == 34 set KMS=kms.xspace.in
    if %%k == 35 set KMS=winkms.tk
    if %%k == 36 set KMS=kms7.MSGuides.com
    if %%k == 37 set KMS=kms8.MSGuides.com
    if %%k == 39 set KMS=kms9.MSGuides.com
    if %%k == 40 set KMS=kms01.yourdomain.com:1688

    cscript ospp.vbs /remhst
    cscript ospp.vbs /sethst:!KMS!
    cscript ospp.vbs /act | find "<Product activation successful>"
    if !errorlevel! == 0 goto aktivaceUspesna
)

cls
set oddeleni=echo =================================================================================================
%oddeleni%
echo Omlouvam se, ale vypada to, ze aktivace nebyla uspesna :(
echo Pokud si myslite, ze jste vse udelali spravne, zkuste se pripojit k VPN a spustit aktivaci znovu
%oddeleni%
echo.
echo Prejete si zobrazit systemovy vypis aktualniho stavu aktivace produktu pro pripadnou opravu chyb? [A/N] (nedoporuceno)

choice /c AN /n
if %errorlevel% == 1 cscript ospp.vbs /dstatusall & cscript ospp.vbs /dstatus

echo.
echo Dekuji za pouzivani aktivatoru :D

pause > nul
exit /b 0

:aktivaceUspesna
cls
set oddeleni=echo =========================================================
%oddeleni%
echo Na zaklade dostupnych informaci byla aktivace uspesna :D
%oddeleni%
echo.
echo Prejete si zobrazit systemovy vypis aktualniho stavu aktivace produktu pro pripadnou opravu chyb? [A/N] (nedoporuceno)

choice /c AN /n
if %errorlevel% == 1 cscript ospp.vbs /dstatusall & cscript ospp.vbs /dstatus

echo Dekuji za pouzivani aktivatoru :D

pause > nul
exit /b 0

:VerError
echo.
echo ERROR!!! Nekde v programu doslo k chybe.
echo Vypada to, ze nejste na spravne verzi operacniho systemu, tento program je urcen pro verzi Windows_NT
echo Vase verze: %OS%
echo Pro opravu programu prosim prepiste kod tak, aby fungoval :DDD
pause > nul
exit /b 2

:PathError
echo.
echo ERROR!!! Nekde v programu doslo k chybe.
echo Program nenasel instalaci Microsoft Office nebo platnou podlozku.
echo MS Office musi byt nainstalovan v "Program Files" nebo "Program Files (x86)" a musi existovat podslozka "\Microsoft Office\Office16"
echo Pro opravu programu prosim prepiste kod tak, aby fungoval :DDD
pause > nul
exit /b 4

:KlicError
cls
echo.
echo ERROR!!! KMS klic nema platny format!
pause > nul
exit /b 3