@echo off

echo ---------- Building Library .dll ----------
cmd.exe /C C:\Users\244910\Documents\abddddd\Mono\bin\csc.bat utils.cs -target:library -out:Build/MUtils.dll
echo ---------- Building Executable .exe ----------
cmd.exe /C C:\Users\244910\Documents\abddddd\Mono\bin\csc.bat main.cs -r:Build/MUtils.dll -out:Build/Mezum.exe
