@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET studentName=%1
SET fileName=%2
if not exist %fileName% (
echo ���� �� ������
) else (
SET buf=findstr /i /C:"%studentName%" %fileName%
if [buf]==[] (
echo ������� �� ������.
exit 0;
) else (
echo ������� ������.
exit /b 1
)
)