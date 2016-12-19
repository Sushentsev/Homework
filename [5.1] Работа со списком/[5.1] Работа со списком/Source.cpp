#include <iostream>
#include "list.h"

using namespace std;

void printInformation()
{
	cout << endl;
	cout << "¬ыберете операцию:" << endl;
	cout << "0 Ц выйти" << endl;
	cout << "1 Ц добавить значение в сортированный список" << endl;
	cout << "2 Ц удалить значение из списка" << endl;
	cout << "3 Ц распечатать список" << endl;
	cout << endl;
}

void addElement(List *list)
{
	int value = 0;
	cout << "¬ведите значение добавл€емого элемента:" << endl;
	cin >> value;
	addElement(list, value);
	cout << "Ёлемент успешно добавлен!" << endl;
}

void removeElement(List *list)
{
	int value = 0;
	cout << "¬ведите значение удал€емого элемента:" << endl;
	cin >> value;
	if (removeElement(list, value))
	{
		cout << "”даление элемента прошло успешно!" << endl;
	}
	else
	{
		cout << "ќшибка при удалении!" << endl;
	}
}

bool test()
{
	List *list = createList();
	bool result = true;
	addElement(list, 10);
	addElement(list, 8);
	addElement(list, 9);
	result = (getValue(list, 2) == 9) && (getValue(list, 3) != 8);
	removeElement(list, 8);
	result = result && (getValue(list, 2) == 10);
	deleteList(list);
	return result;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Test: " << test() << endl;

	List *list = createList();
	short selection = -1;

	while (selection != 0)
	{
		printInformation();
		cin >> selection;
		switch (selection)
		{
		case 1:
			addElement(list);
			break;
		case 2:
			removeElement(list);
			break;
		case 3:
			printList(list);
			break;
		default:
			break;
		}
	}

	deleteList(list);
}