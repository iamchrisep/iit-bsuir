// Lab1.cpp: ���������� ����� ����� ��� ����������� ����������.
//
// ����������� �����, ����� �� ��������� �������� ��������  
// ���������� ������ � ������� ������� (�� ��������� � ������), 
// ����������� �������� ������� ����� �� ���������� ������. 
// ���������� ������� (������) �� � ����� ���������� � ���� 
// ������� ������� ������� �� �����.

#include "stdafx.h"
#include <stdio.h>
#include <string.h>
#include "DeleteWord.h"

int main()
{
	DeleteWord * obj1;
	DeleteWord * obj2;

	cout << "::: The first object: :::\n\n";
	obj1 = new DeleteWord();
	obj1->SetNewString("My new string");
	cout << "Source string: ";
	PrintSourceString(*obj1);
	cout << "\nString after processing: ";
	obj1->DeleteSecondWord();

	cout << "\n\n::: The second object: :::\n\n";
	obj2 = new DeleteWord();
	obj2->SetNewString("    This text string very long	 ");
	cout << "Source string: ";
	PrintSourceString(*obj2);
	cout << "\nString after processing: ";
	obj2->DeleteSecondWord();
	cout << "\n\n";

	delete obj1;
	delete obj2;

	system("pause");

	return 0;
}
