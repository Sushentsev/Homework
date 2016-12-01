#include <iostream>
#include "list.h"
#include <string>

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
	list->size = 0;
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

void addElement(ListElement *head, std::string word, int value)
{
	ListElement *newElement = createListElement(word, value, head);
	head = newElement;
}

bool isEmpty(ListElement *head)
{
	return head == nullptr;
}


int amountOfElements(ListElement *head)
{
	int count = 0;
	ListElement *cursor = head;
	while (cursor != nullptr)
	{
		++count;
		cursor = cursor->next;
	}
	return count;
}


bool isContained(ListElement *head, std::string word)
{
	ListElement *cursor = head;
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

void increaseIfFoundAddOtherwise(ListElement *head, std::string word)
{
	ListElement *cursor = head;
	if (isContained(head, word))
	{
		while (cursor->word != word)
		{
			cursor = cursor->next;
		}
		++cursor->value;
	}
	else
	{
		addElement(head, word, 1);
	}
}

void printList(ListElement *head)
{
	ListElement *cursor = head;
	while (cursor != nullptr)
	{
		std::cout << " ' " << cursor->word << " ' (" << cursor->value << ") ";
	}
}

void deleteList(ListElement *head)
{
	ListElement *toDelete = head;
	while (toDelete != nullptr)
	{
		head = head->next;
		delete toDelete;
		toDelete = head;
	}
}





