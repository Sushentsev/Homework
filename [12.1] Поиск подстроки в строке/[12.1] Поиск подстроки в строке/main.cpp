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
		std::cout << "ќшибка при открытии файла" << std::endl;
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

	if (!isContained(needle, haystack[haystackLength - 1]))
	{
		push(stopSymbols, haystack[haystackLength - 1], 0);
	}
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

	std::cout << "¬ведите образец:" << std::endl;
	getline(std::cin, needle);

	const int needleLength = needle.length();

	loadFromFile(haystack);
	inputStopSymbols(stopSymbols, needle, haystack);
	printStack(stopSymbols);
	deleteStack(stopSymbols);
}