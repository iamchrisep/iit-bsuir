@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET fileName=%1
if not exist %fileName%.txt (
echo Искомый файл не найден
) else (
"C:\Program Files\WinRAR\Rar.exe" a "%fileName%.rar" "%fileName%.txt"
)