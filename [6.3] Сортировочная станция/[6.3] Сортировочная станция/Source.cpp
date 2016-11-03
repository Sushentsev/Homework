#include <iostream>
#include "Stack.h"
#include <string>

int direction(char element)
{
	int status = -1;

	return status;
}

int fromInfixFormToPostFix(Stack *stack, const std::string &infixForm, std::string &postfixForm)
{
	int status = -1;
	for (int i = 0; i < infixForm.length(); ++i)
	{
		if (infixForm[i] != ' ')
		{
			while (status != 1)
			{
				status = direction(infixForm[i]);
				switch (status)
				{
				case 1:
					push(stack, infixForm[i]);
					break;
				case 2:
					postfixForm += pop(stack);
					break;
				case 3:
					pop(stack);
					break;
				case 4:
					return status;
					break;
				case 5:
					return status;
					break;
				default:
					break;
				}
			}
		}
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
	infixForm += "|";
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