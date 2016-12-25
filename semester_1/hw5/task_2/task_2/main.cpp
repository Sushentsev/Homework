#include "circularList.h"
#include <iostream>

using namespace std;

bool test1()
{
	const int n = 10;
	const int m = 3;

	auto list = createList();
	createSquad(list, n);
	int result = survivor(list, m);
	removeList(list);

	return result == 4;
}

bool test2()
{
	const int n = 6;
	const int m = 1;

	auto list = createList();
	createSquad(list, n);
	int result = survivor(list, m);
	removeList(list);

	return result == 6;
}

bool test3()
{
	const int n = 2;
	const int m = 2;

	auto list = createList();
	createSquad(list, n);
	int result = survivor(list, m);
	removeList(list);

	return result == 1;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;
	cout << "Test 3: " << test3() << endl;
	int n = 0;
	int m = 0;
	auto list = createList();
	cout << "Введите количество войнов (n) и номер человека, которого убивают (m)" << endl;
	cin >> n >> m;
	if (n > 1 && m > 0)
	{
		createSquad(list, n);
		cout << "Выживший имеет номер " << survivor(list, m) << endl;
	}
	else
	{
		cout << "Неверные входные данные!" << endl;
	}
	removeList(list);
}