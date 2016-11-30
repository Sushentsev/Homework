#include <iostream>
#include "list.h"

struct ListElement
{
	std::string word;
	int value;
	ListElement *next;
};

struct List
{
	ListElement *head;
};

List *createList()
{
	List *list = new List;
	list->head = nullptr;
	return list;
}

ListElement *createListElement(std::string word, int value, ListElement *next)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	newElement->word = word;
	return newElement;
}

bool isEmpty(List *list)
{
	return list->head == nullptr;
}

bool isContained(List *list, std::string word)
{
	ListElement *cursor = list->head;
	while (cursor != nullptr)
	{
		if (cursor->word == word)
		{
			return true;
		}
		cursor = cursor->next;
	}
	return false;
}

void addElement(List *list, std::string word, int value)
{
	ListElement *newElement = createListElement(word, value, list->head);
	list->head = newElement;
}

void increaseIfFoundAddOtherwise(List *list, std::string word)
{
	ListElement *cursor = list->head;
	if (isContained(list, word))
	{
		while (cursor->word != word)
		{
			cursor = cursor->next;
		}
		++cursor->value;
	}
	else
	{
		addElement(list, word, 1);
	}
}

void deleteList(List *list)
{
	ListElement *toDelete = list->head;
	while (toDelete != nullptr)
	{
		list->head = list->head->next;
		delete toDelete;
		toDelete = list->head
	}
}



