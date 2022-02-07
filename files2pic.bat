@echo off
if exist files\cover.png (
  goto execute
) else (
  echo Please Create a Folder named "files" and place a picture named "cover.png" there, along with the files you want to hide!
  pause
  exit
)

:execute
set picpath=%CD%\cover.png
set filename=cover.png
set zippath=%CD%\files
set ogdir=%CD%
md %TMP%\files2pic
copy %picpath% %TMP%\files2pic >nul
echo Copied Cover Picture
copy %zippath%\* %TMP%\files2pic >nul
echo Copied Files
cd %TMP%\files2pic
jar -cfM compressedPic.zip * >nul
echo Created Archive
copy /b %filename%+compressedPic.zip hidden000.png >nul
echo Added Cover Picture to Archive
cd %ogdir%
copy %TMP%\files2pic\hidden000.png files2pic-output.png >nul
echo Outputted File
del /Q %TMP%\files2pic >nul
echo Deleted Temp Folder
echo Done! Press any key to exit...
pause >nul
exit

