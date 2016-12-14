#include <iostream>
#include <fstream>
#include <string>
#include "stack.h"


void loadFromFile(std::string &haystack)
{
	std::ifstream file("input.txt");
	if (file.is_open())
	{
		getline(file, haystack, '\0');
		file.close();
	}
	else
	{
		std::cout << "Ошибка при открытии файла" << std::endl;
	}
}

bool isContained(const std::string &needle, char symbol)
{
	const int needleLength = needle.length();
	for (int i = 0; i < needleLength; ++i)
	{
		if (needle[i] == symbol)
		{
			return true;
		}
	}
	return false;
}

void pushOrChange(Stack *stopSymbols, char symbol, int value)
{
	if (isContained(stopSymbols, symbol))
	{
		changeValue(stopSymbols, symbol, value);
	}
	else
	{
		push(stopSymbols, symbol, value);
	}
}

void inputStopSymbols(Stack *stopSymbols, const std::string &needle, const std::string &haystack)
{
	const int haystackLength = haystack.length();

	for (int i = 0; i < haystackLength - 1; ++i)
	{
			pushOrChange(stopSymbols, haystack[i], i + 1);
	}
	
	if (!isContained(stopSymbols, haystack[haystackLength - 1]))
	{
		push(stopSymbols, haystack[haystackLength - 1], 0);
	}
}

int firstPosition(Stack *stopSymbols, const std::string &needle, const std::string &haystack)
{
	const int haystackLength = haystack.length();
	const int needleLength = needle.length();
	int position = needleLength;
	while (position < haystackLength)
	{
		if (haystack[position - 1] != needle[needleLength - 1])
		{
			position += returnValue(stopSymbols, haystack[position - 1]);
		}
		else
		{
			int count = 0;
			int needlePosition = needleLength - 1;
			int haystackPosition = position;

			while ((haystack[haystackPosition] == needle[needlePosition]) && (haystackPosition >= 0) && (needlePosition >= 0))
			{
				++count;
				--needlePosition;
				--haystackPosition;
			}

			if (needleLength == count)
			{
				break;
			}
			else
			{
				++position;
			}
		}
	}
	
	if (position >= haystackLength)
	{
		position = -1;
	}
	else
	{
		position -= needleLength;
	}

	return position;
}

void test1()
{
	Stack *stack = createStack();
	push(stack, 'a', 1);
	push(stack, 'b', 2);
	push(stack, 'd', 3);
	std::cout << "Is empty: " << isEmpty(stack) << std::endl;
	std::cout << "Is contained (a): " << isContained(stack, 'a') << std::endl;
	std::cout << "Is contained (c): " << isContained(stack, 'c') << std::endl;
	std::cout << "Value (b): " << returnValue(stack, 'b') << std::endl;
	changeValue(stack, 'b', 10);
	std::cout << "Value (b): " << returnValue(stack, 'b') << std::endl;
	printStack(stack);
	pop(stack);
	printStack(stack);
	deleteStack(stack);
	std::cout << std::endl << std::endl;
}

void main()
{

	setlocale(LC_ALL, "Russian");
	Stack *stopSymbols = createStack();
	std::string haystack = "";
	std::string needle = "";

	std::cout << "Введите образец:" << std::endl;
	getline(std::cin, needle);

	const int needleLength = needle.length();

	loadFromFile(haystack);
	inputStopSymbols(stopSymbols, needle, haystack);
	std::cout << "Первая позиция: " << firstPosition(stopSymbols, needle, haystack) << std::endl;
 	deleteStack(stopSymbols);
}