@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul
SET studentName=%1
SET newStudentName=%2
SET fileName=%3
if not exist %fileName% (
echo ������� ���� �� ������
) else (
findstr /i /v /C:"%studentName%" %fileName%>temp.txt
del %fileName%
rename temp.txt %fileName%
echo %newStudentName%>>%fileName%
sort %fileName% /Output %fileName%
echo ������� %studentName% ������ ������� ��� %newStudentName% � %fileName% 
)