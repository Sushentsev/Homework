#include <iostream>

struct ListElement
{
	int value;
	ListElement *next;
};

struct List
{
	int length = 0;
	ListElement *head;
	ListElement *tale;
};

List *createList()
{
	List *list = new List;
	list->length = 0;
	list->head = nullptr;
	list->tale = nullptr;
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
	if (n >= 1)
	{
		ListElement *temp = createListELement(1, nullptr);
		list->head = temp;
		list->tale = temp;
		++list->length;
	}
	if (n >= 2)
	{
		ListElement *temp = createListELement(2, list->head);
		list->head->next = temp;
		list->tale = temp;
		++list->length;
	}
	if (n >= 3)
	{
		for (int i = 3; i <= n; ++i)
		{
			ListElement *temp = createListELement(i, list->head);
			list->tale->next = temp;
			list->tale = temp;
			++list->length;
		}
	}
}

int survivor(List *list, int m)
{
	if (m >= 1)
	{
		while (list->length != 1)
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
			--list->length;
		}
	}
	return list->head->value;
}

void deleteList(List *list)
{
	delete list->head;
	list->head = nullptr;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int n = 0;
	int m = 0;
	List *list = createList();
	std::cout << "Введите количество войнов (n) и номер человека, которого убивают (m)" << std::endl;
	std::cin >> n >> m;
	createSquard(list, n);
	std::cout << "Выживший имеет номер " << survivor(list, m) << std::endl;
	deleteList(list);
	delete list;
}