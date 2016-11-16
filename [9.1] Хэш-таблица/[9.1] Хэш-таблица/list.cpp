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
	List *list = new List{ nullptr };
	return list;
}

ListElement *createListElement(std::string word, int value, ListElement *next)
{
	ListElement *newElement = new ListElement{ word, value, nullptr };
	return newElement;
}

bool isEmpty(List *list)
{
	return (list->head == nullptr);
}

void addElement(ListElement *head, std::string word, int value)
{
	ListElement *newElement = createListElement(word, value, head);
	head = newElement;
}

void removeElement(ListElement *&element, int value)
{
	if (element == nullptr)
	{
		return;
	}
	if (element->value == value)
	{
		ListElement *toDelete = element;
		element = element->next;
		delete toDelete;
	}
	else
	{
		removeElement(element->next, value);
	}
}

void removeElement(List *list, int value)
{
	removeElement(list->head, value);
}

void deleteList(ListElement *&element)
{
	while (element != nullptr)
	{
		ListElement *toDelete = element;
		element = element->next;
		delete toDelete;
	}
}

void deleteList(List *list)
{
	deleteList(list->head);
	delete list;
}

bool increaseIfFound(ListElement *listElement, std::string word)
{
	while (listElement != nullptr)
	{
		if (listElement->word == word)
		{
			++listElement->value;
			return true;
		}
	}
	return false;
}


void printList(ListElement *element)
{
	while (element != nullptr)
	{
		std::cout << element->value << " ";
		element = element->next;
	}
}

void printList(List *list)
{
	printList(list->head);
}

