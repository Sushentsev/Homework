#include <iostream>
#include "Stack.h"
#include <string>

using namespace std;

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
		else if (element == ')' && c == '(')
		{
			status = 3;
		}
		else if (((c == '+' || c == '-' || c == '*' || c == '/') && (element == '|' || element == '+' || element == '-' || element == ')')) 
			|| ((c == '*' || c == '/') && (element == '*' || element == '/' || element == ')')))
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

int fromInfixFormToPostFix(Stack *stack, const string &infixForm, string &postfixForm)
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

bool test1()
{
	auto stack = createStack();
	int status = 0;
	string infixForm = "(1+2)*4|";
	string postfixForm = "";
	status = fromInfixFormToPostFix(stack, infixForm, postfixForm);
	deleteStack(stack);
	return (status == 4 && postfixForm == "1 2 + 4 * ");
}

bool test2()
{
	auto stack = createStack();
	int status = 0;
	string infixForm = "(8+2* 5)/(1+ 3 *2-4)|";
	string postfixForm = "";
	status = fromInfixFormToPostFix(stack, infixForm, postfixForm);
	deleteStack(stack);
	return (status == 4 && postfixForm == "8 2 5 * + 1 3 2 * + 4 - / ");
}

bool test3()
{
	auto stack = createStack();
	int status = 0;
	string infixForm = "((7 +  5)|";
	string postfixForm = "";
	status = fromInfixFormToPostFix(stack, infixForm, postfixForm);
	deleteStack(stack);
	return (status == 5);
}

void main()
{
	setlocale(LC_ALL, "Russian");
	auto stack = createStack();
	int status = 0;
	string infixForm = "";
	string postfixForm = "";
	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;
	cout << "Test 3: " << test3() << endl;
	cout << "Введите выражение в инфиксной форме:" << endl;
	getline(cin, infixForm);
	infixForm = infixForm + "|";
	status = fromInfixFormToPostFix(stack, infixForm, postfixForm);
	if (status == 4)
	{
		cout << "Постфиксная форма выражения: " << postfixForm << endl;
	}
	else
	{
		cout << "Произошла ошибка при переводе" << endl;
	}
	deleteStack(stack);
}