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
	int length = 0;
};

List *createList()
{
	List *list = new List;
	list->head = nullptr;
	list->length = 0;
	return list;
}

ListElement *createListELement(int value, ListElement *next)
{
	ListElement *newListElement = new ListElement;
	newListElement->value = value;
	newListElement->next = next;
	return newListElement;
}

void createSquard(List *list, int n)
{
	list->head = createListELement(1, list->head);
	++list->length;
	ListElement *lastElement = list->head;
	for (int i = 2; i <= n; ++i)
	{
		ListElement *newElement = createListELement(i, list->head);
		lastElement->next = newElement;
		lastElement = newElement;
		++list->length;
	}
}

int survivor(List *list, int m)
{
	while (list->length != 1)
	{
		if (m == 1)
		{
			ListElement *cursor = list->head;
			while (cursor->next != list->head)
			{
				cursor = cursor->next;
			}
			return cursor->value;
		}
		else
		{
			ListElement *toDelete = list->head;
			for (int i = 1; i < m - 1; ++i)
			{
				toDelete = toDelete->next;
			}
			list->head = toDelete;
			toDelete = toDelete->next;
			list->head->next = list->head->next->next;
			list->head = list->head->next;
			delete toDelete;
			toDelete = nullptr;
			--list->length;
		}
	
	}
	return list->head->value;
}

void deleteList(List *list)
{
	while (list->head != nullptr)
	{
		ListElement *toDelete = list->head;
		list->head = list->head->next;
		delete toDelete;
		toDelete = nullptr;
	}
}

bool test1()
{
	const int n = 10;
	const int m = 3; 

	List *list = createList();
	createSquard(list, n);
	int result = survivor(list, m);
	delete list;
	list = nullptr;

	return result == 4;
}

bool test2()
{
	const int n = 6;
	const int m = 1;

	List *list = createList();
	createSquard(list, n);
	int result = survivor(list, m);
	delete list;
	list = nullptr;

	return result == 6;
}

bool test3()
{
	const int n = 2;
	const int m = 2;

	List *list = createList();
	createSquard(list, n);
	int result = survivor(list, m);
	delete list;
	list = nullptr;

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
	List *list = createList();
	cout << "Введите количество войнов (n) и номер человека, которого убивают (m)" << endl;
	cin >> n >> m;
	if (n > 1 && m > 0)
	{
		createSquard(list, n);
		cout << "Выживший имеет номер " << survivor(list, m) << endl;
		deleteList(list);
		delete list;
		list = nullptr;
	}
	else
	{
		cout << "Неверные входные данные!" << endl;
	}

}