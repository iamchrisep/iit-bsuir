#include "stdafx.h"
#include <stdio.h>
#include <string.h>
#include "DeleteWord.h"

// Конструктор.
DeleteWord::DeleteWord()
{
	str = new char[1];
	str[0] = '\0';
}

// char * Конструктор.
DeleteWord::DeleteWord(const char * ch)
{
	str = new char[strlen(ch) + 1];
	strcpy(str, ch);
}

// Конструктор копирования.
DeleteWord::DeleteWord(DeleteWord &rhs)
{
	str = new char[strlen(rhs.str) + 1];
	strcpy(str, rhs.str);
}

// Деструктор.
DeleteWord::~DeleteWord()
{
	delete[] str;
}

// Проверка строки.
bool DeleteWord::CheckString() const
{
	char * buffer = TrimString();
	if (strlen(buffer) == 0)
	{
		cout << "\nError #1: The string is empty!";
		return false;
	}

	if (strchr(buffer, ' ') == NULL)
	{
		cout << "\nError #2: There is only one word in string!";
		return false;
	}
	return 1;
}

// Удаление ненужных символов.
char * DeleteWord::TrimString() const
{
	char * buffer = new char[strlen(str) + 1];
	strcpy(buffer, str);

	// Удаление пробелов и табов в начала строки.
	int i = 0, j;
	while ((buffer[i] == ' ') || (buffer[i] == '\t'))
	{
		i++;
	}
	if (i>0)
	{
		for (j = 0; j< int(strlen(buffer)); j++)
		{
			buffer[j] = buffer[j + i];
		}
		buffer[j] = '\0';
	}


	// Удаление пробелов и табов в конце строки.
	i = strlen(buffer) - 1;
	while ((buffer[i] == ' ') || (buffer[i] == '\t'))
	{
		i--;
	}
	if (i<int(strlen(buffer) - 1))
	{
		buffer[i + 1] = '\0';
	}

	return buffer;
}

// Вывод строки на экран. (friend - функция)
void PrintSourceString(const DeleteWord & src)
{
	cout << src.str;
}

// Ввод строки.
DeleteWord & DeleteWord::SetNewString(const char * newstr)
{
	delete[] str;
	str = new char[strlen(newstr) + 1];
	strcpy(str, newstr);
	return *this;
}

// Удаление второго слова.
char * DeleteWord::DeleteSecondWord()
{
	if (!CheckString())
	{
		return NULL;
	}
	else
	{
		char * buffer = TrimString();
		int bufferlen = strlen(buffer);

		char * ptFirst = strchr(buffer, ' ');
		int firstStrLen = ptFirst - buffer;
		
		int otherBufStrLen = bufferlen - firstStrLen;
		char * otherBufString = new char[otherBufStrLen + 1];
		strcpy(otherBufString, ptFirst);

		char * buf = new char[otherBufStrLen + 1];
		strcpy(buf, otherBufString);
		int i = 0, j;
		while ((buf[i] == ' ') || (buf[i] == '\t'))
		{
			i++;
		}
		if (i>0)
		{
			for (j = 0; j< int(strlen(buf)); j++)
			{
				buf[j] = buf[j + i];
			}
			buf[j] = '\0';
		}


		char * strBuf = new char[strlen(buf) + 1];
		strcpy(strBuf, buf);

		char * ptSecond = strchr(strBuf, ' ');
		int secondStrLen = ptSecond - strBuf;
		int otherStrLen = strlen(strBuf) - secondStrLen;

		char * res = new char[bufferlen + 1];
		char * firstWord = new char[firstStrLen + 1];
		char * secondWord = new char[secondStrLen + 1];
		char * otherString = new char[otherStrLen + 1];

		res[0] = '\0';
		firstWord[firstStrLen] = '\0';
		secondWord[secondStrLen] = '\0';
		otherString[otherStrLen] = '\0';

		strncpy(firstWord, buffer, firstStrLen);
		strncpy(secondWord, buffer, secondStrLen);
		strncpy(otherString, ptSecond, otherStrLen);

		strcat(res, firstWord);
		strcat(res, otherString);

		delete[] firstWord;
		delete[] secondWord;
		delete[] otherString;
		delete[] buffer;

		cout << res << endl;
		return res;
	}
}
