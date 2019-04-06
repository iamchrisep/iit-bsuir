#ifndef DELETEWORD
#define DELETEWORD

#include <iostream>
#include <string.h>
#include <Windows.h>

using namespace std;

// Класс для обмена позиции первого и последнего слова в строке.
class DeleteWord
{
public:
	// Конструкторы.
	DeleteWord();
	explicit DeleteWord(const char *);

	// Конструктор копирования.
	DeleteWord(DeleteWord &rhs);

	// Деструктор.
	~DeleteWord();

	// Методы.
	friend void PrintSourceString(const DeleteWord & src);
	DeleteWord & SetNewString(const char *);
	char * DeleteSecondWord();

private:
	char * str;
	bool CheckString() const;
	char * TrimString() const;
};

#endif
