@echo off
SETLOCAL EnableDelayedExpansion
chcp 1251 >nul

:main
echo �������� ����� ����:
echo.
echo 1 - �������� ��� ���������� ������ ������ ���������
echo 2 - ������ �������� � ������
echo 3 - ���������� �������� �� ������
echo 4 - ��������� ������ ������ � ����������� �����
echo 5 - ���������� ������ ������ �� ������������ ������
echo 6 - ����� ���������
echo 0 - �����

echo.
SET /p choice="��� �����: "
if not defined choice goto main
if %choice%==1 (goto job1)
if %choice%==2 (goto job3)
if %choice%==3 (goto job2)
if %choice%==4 (goto job4)
if %choice%==5 (goto job5)
if %choice%==6 (goto job6)
if %choice%==0 (goto end)
echo.
echo ������������ �����!
echo.
echo.

goto main

:job1
call job1.bat 581072.txt
goto main

:job2
set /p studentName=������� ������� ��������:
call job2.bat %studentName% 581072.txt
goto main

:job3
set /p studentName=������� ������� �����������:
echo.
set /p newStudentName=������� ������� �����������:
call job3.bat %studentName% %newStudentName% 581072.txt
goto main

:job4
call job4.bat 581072
goto main

:job5
call job5.bat 581072
goto main

:job6
set /p studentName=������� ������� ��������:
call job6.bat %studentName% 581072.txt
goto main

:end