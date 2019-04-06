@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET fileName=%1
if not exist %fileName%.rar (
echo Искомый файл не найден
) else (
"C:\Program Files\WinRAR\Rar.exe" e "%fileName%.rar"
)