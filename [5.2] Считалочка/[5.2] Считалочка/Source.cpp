#include <iostream>

using namespace std;

struct ListElement
{
	int value;
	ListElement *next;
};

struct List
{
	ListElement *head;
	int length;
};

List *createList()
{
	auto list = new List{ nullptr, 0 };
	return list;
}

ListElement *createListELement(int value, ListElement *next)
{
	auto newListElement = new ListElement{ value, next };
	return newListElement;
}

bool isEmpty(List *list)
{
	return list->length == 0;
}

void createSquad(List *&list, int n)
{
	list->head = createListELement(1, list->head);
	auto lastElement = list->head;
	++list->length;

	for (int i = 2; i <= n; ++i)
	{
		lastElement->next = createListELement(i, list->head);
		lastElement = lastElement->next;
		++list->length;
	}
}

void removeElement(ListElement *&head, ListElement *&previousElement)
{
	auto toDelete = previousElement->next;
	previousElement->next = previousElement->next->next;
	if (toDelete == head)
	{
		head = previousElement->next;
	}
	delete toDelete;
}

int survivor(List *&list, int m)
{
	auto cursor = list->head;

	while (list->length > 1)
	{
		if (m == 1)
		{
			auto cursor = list->head;
			while (cursor->next != list->head)
			{
				cursor = cursor->next;
			}
			return cursor->value;
		}
		else
		{
			for (int i = 1; i < m - 1; ++i)
			{
				cursor = cursor->next;
			}

			removeElement(list->head, cursor);
			cursor = cursor->next;
			--list->length;
		}
	}

	return list->head->value;
}

void removeList(List *&list)
{
	while (list->head->next != list->head)
	{
		removeElement(list->head, list->head);
	}
	delete list->head;
	delete list;
	list = nullptr;
}

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
		removeList(list);
	}
	else
	{
		cout << "Неверные входные данные!" << endl;
	}

}