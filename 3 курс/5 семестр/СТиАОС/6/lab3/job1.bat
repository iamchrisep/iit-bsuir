@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET fileName=%1
if not exist %fileName% (
echo off >>%fileName%)
set /P studentName=������� ������� ��������: 
echo %studentName%>>%fileName%
sort %fileName% /Output %fileName%