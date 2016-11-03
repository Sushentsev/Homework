#include <iostream>
#include "Stack.h"
#include <string>

int direction(const std::string element)
{
	int status = -1;

	return status;
}

int fromInfixFormToPostFix(Stack *stack, const std::string &infixForm, std::string &postfixForm)
{
	int status = -1;
	for (int i = 0; i < infixForm.length(); ++i)
	{

	}
	return status;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	Stack *stack = createStack();
	int status = 0;
	std::string infixForm = "";
	std::string postfixForm = "";
	std::cout << "Введите выражение в инфиксной форме:" << std::endl;
	std::getline(std::cin, infixForm);
	infixForm = infixForm + "|";
	status = fromInfixFormToPostFix(stack, infixForm, postfixForm);
	if (status == 4)
	{
		std::cout << "Постфиксная форма выражения: " << postfixForm << std::endl;
	}
	else
	{
		std::cout << "Произошла ошибка при переводе" << std::endl;
	}
	deleteStack(stack);
	delete stack;
	stack = nullptr;
}