#include <iostream>
#include <string>
#include "Stack.h"

using namespace std;

int result(Stack *stack, const string &s)
{
	for (int i = 0; i < s.length(); ++i)
	{
		int value1 = 0;
		int value2 = 0;
		char c[1] = { s[i] };
		if ((c[0] >= '0') && (c[0] <= '9'))
		{
			push(stack, atoi(c));
		}
		switch (c[0])
		{
		case '+':
			value1 = pop(stack);
			value2 = pop(stack);
			push(stack, value1 + value2);
			break;
		case '-':
			value1 = pop(stack);
			value2 = pop(stack);
			push(stack, value2 - value1);
			break;
		case '*':
			value1 = pop(stack);
			value2 = pop(stack);
			push(stack, value1 * value2);
			break;
		case '/':
			value1 = pop(stack);
			value2 = pop(stack);
			push(stack, value2 / value1);
			break;
		default:
			break;
		}
	}
	return pop(stack);
}

bool test()
{
	Stack *stack = createStack();
	string s = "9 6 - 1 2 + *";
	return result(stack, s) == 9;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	Stack *stack = createStack();
	string s = "";
	cout << "Test: " << test() << endl;
	cout << "¬ведите выражение в постфиксной записи:" << endl;
	getline(cin, s);
	cout << "«начение примера равно: " << result(stack, s) << endl;
	deleteStack(stack);
}