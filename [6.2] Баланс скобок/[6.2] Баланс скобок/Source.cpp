#include <iostream>
#include <string>
#include "Stack.h"

int result(Stack *stack, std::string s)
{
	bool result = 1;
	for (int i = 0; i < s.length(); ++i)
	{
		char c = s[i];
		if ((c == '[') || (c == '(') || (c == '{'))
		{
			push(stack, c);
		}
		else if (c == ']')
		{
			result = result && (pop(stack) == '[');
		}
		else if (c == ')')
		{
			result = result && (pop(stack) == '(');
		}
		else if (c == '}')
		{
			result = result && (pop(stack) == '{');
		}
	}
	result = result && isEmpty(stack);
	return result;
}

bool test1()
{
	Stack *stack = createStack();
	std::string s = "([hello])";
	return result(stack, s) == 1;
}

bool test2()
{
	Stack *stack = createStack();
	std::string s = "([hello)";
	return result(stack, s) == 0;
}

bool test3()
{
	Stack *stack = createStack();
	std::string s = "()[()]{()()[]}";
	return result(stack, s) == 1;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	Stack *stack = createStack();
	std::string s = "";
	std::cout << "Test 1: " << test1() << std::endl;
	std::cout << "Test 2: " << test2() << std::endl;
	std::cout << "Test 3: " << test3() << std::endl;
	std::cout << "Введите строку:" << std::endl;
	std::getline(std::cin, s);
	std::cout << "Совпадение скобок: " << result(stack, s) << std::endl;
	deleteStack(stack);
	delete stack;
	stack = nullptr;
}