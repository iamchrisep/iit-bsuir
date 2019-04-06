#ifndef DELETEWORD
#define DELETEWORD

#include <iostream>
#include <string.h>
#include <Windows.h>

using namespace std;

// ����� ��� ������ ������� ������� � ���������� ����� � ������.
class DeleteWord
{
public:
	// ������������.
	DeleteWord();
	explicit DeleteWord(const char *);

	// ����������� �����������.
	DeleteWord(DeleteWord &rhs);

	// ����������.
	~DeleteWord();

	// ������.
	friend void PrintSourceString(const DeleteWord & src);
	DeleteWord & SetNewString(const char *);
	char * DeleteSecondWord();

private:
	char * str;
	bool CheckString() const;
	char * TrimString() const;
};

#endif
