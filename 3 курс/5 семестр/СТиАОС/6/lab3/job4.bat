@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET fileName=%1
if not exist %fileName%.txt (
echo ������� ���� �� ������
) else (
"C:\Program Files\WinRAR\Rar.exe" a "%fileName%.rar" "%fileName%.txt"
)