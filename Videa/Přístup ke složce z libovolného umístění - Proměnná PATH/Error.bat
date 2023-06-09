@echo off
cd /d C:\Users\Public
echo x=MsgBox("Tento program je velice uzitecny, protoze ihned po spusteni zobrazi error a kdo by neco takoveho nechtel?                                                                                                               Mimochodem, dejte odber :D", 0+16, "ERROR!!!") > error.vbs
timeout /t 0 > nul
error.vbs
timeout /t 0 > nul
del error.vbs
exit