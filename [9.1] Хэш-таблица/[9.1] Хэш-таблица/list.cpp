#include <iostream>
#include <string>
#include "list.h"

struct ListElement
{
	std::string word;
	int value;
	ListElement *next;
};

ListElement *createListElement(const std::string &word, int value, ListElement *next)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	newElement->word = word;
	return newElement;
}

bool isEmpty(ListElement *head)
{
	return (head == nullptr);
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

bool isContained(ListElement *head, const std::string &word)
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

void increaseIfFoundAddOtherwise(ListElement *head, const std::string &word)
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
		ListElement *newElement = createListElement(word, 1, head);
		head = newElement;
	}
}

void printList(ListElement *head)
{
	ListElement *cursor = head;
	while (cursor != nullptr)
	{
		std::cout << " ' " << cursor->word << " ' (" << cursor->value << ") ";
		cursor = cursor->next;
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





