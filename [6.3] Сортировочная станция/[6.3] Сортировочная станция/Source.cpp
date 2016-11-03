#include <iostream>
#include "Stack.h"
#include <string>

int postfixForm(const std::string &infixform)
{
	std::string postfix = "";
}

void main()
{
	setlocale(LC_ALL, "Russian");
	Stack *stack = createStack();
	std::string infixForm = "";
	std::cout << "¬ведите выражение в инфиксной форме:" << std::endl;
	std::getline(std::cin, infixForm);

	delete stack;
	stack = nullptr;
}