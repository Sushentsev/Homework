#include <iostream>
#include "Stack.h"
#include <string>

int direction(Stack *stack, char element)
{
	int status = -1;
	if (isEmpty(stack))
	{ 
		if (element == '|')
		{
			status = 4;
		}
		else if (element == ')')
		{
			status = 5;
		}
		else
		{
			status = 1;
		}
	}
	else
	{
		char c = pop(stack);
		push(stack, c);
		if (element == '|' && c == '(')
		{
			status = 5;
		}
		if (element == ')' && c == '(')
		{
			status = 3;
		}
		if (((c == '+' || c == '-' || c == '*' || c == '/') && (element == '|' || element == '+' || element == '-' || element == ')')) 
			|| ((c == '*' || c == '/') && (element == '*' || element == '/')))
		{
			status = 2;
		}
		else
		{
			status = 1;
		}
	}
	return status;
}

int fromInfixFormToPostFix(Stack *stack, const std::string &infixForm, std::string &postfixForm)
{
	int status = -1;
	for (int i = 0; i < infixForm.length(); ++i)
	{
		if (infixForm[i] != ' ')
		{
			if (isdigit(infixForm[i]))
			{
				postfixForm = postfixForm + infixForm[i] + ' ';
			}
			else
			{
				status = direction(stack, infixForm[i]);
				while (status == 2)
				{
					postfixForm = postfixForm + pop(stack) + ' ';
					status = direction(stack, infixForm[i]);
				}
				switch (status)
				{
				case 1:
					push(stack, infixForm[i]);
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