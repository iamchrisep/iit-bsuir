@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET fileName=%1
if not exist %fileName%.rar (
echo ������� ���� �� ������
) else (
"C:\Program Files\WinRAR\Rar.exe" e "%fileName%.rar"
)