#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void loadFromFile(string &haystack)
{
	ifstream file("input.txt");
	if (file.is_open())
	{
		getline(file, haystack, '\0');
		file.close();
	}
	else
	{
		cout << "ќшибка при открытии файла" << endl;
	}
}



void test1()
{
	Stack *stack = createStack();
	push(stack, 'a', 1);
	push(stack, 'b', 2);
	push(stack, 'd', 3);
	cout << "Is empty: " << isEmpty(stack) << endl;
	cout << "Is contained (a): " << isContained(stack, 'a') << endl;
	cout << "Is contained (c): " << isContained(stack, 'c') << endl;
	cout << "Value (b): " << returnValue(stack, 'b') << endl;
	cout << "Value (b): " << returnValue(stack, 'b') << endl;
	printStack(stack);
	pop(stack);
	printStack(stack);
	deleteStack(stack);
	cout << endl << endl;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	string haystack = "";
	string needle = "";
	cout << "¬ведите образец:" << endl;
	getline(cin, needle);
	loadFromFile(haystack);
}