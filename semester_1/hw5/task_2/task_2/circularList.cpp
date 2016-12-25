#include "circularList.h"
#include <iostream>

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
	return new List{ nullptr, 0 };
}

ListElement *createListELement(const int value, ListElement *next)
{
	return new ListElement{ value, next };
}

bool isEmpty(List *list)
{
	return (list->length == 0);
}

void createSquad(List *&list, const int n)
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

int survivor(List *&list, const int m)
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
	if (!isEmpty(list))
	{
		while (list->head->next != list->head)
		{
			removeElement(list->head, list->head);
		}
		delete list->head;
		list->head = nullptr;
	}
	delete list;
	list = nullptr;
}