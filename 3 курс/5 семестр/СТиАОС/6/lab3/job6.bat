@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET studentName=%1
SET fileName=%2
if not exist %fileName% (
echo Файл не найден
) else (
SET buf=findstr /i /C:"%studentName%" %fileName%
if [buf]==[] (
echo Студент не найден.
exit 0;
) else (
echo Студент найден.
exit /b 1
)
)