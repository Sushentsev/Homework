#include <iostream>
#include <string>
#include "list.h"

using namespace std;

struct ListElement
{
	string word;
	int value;
	ListElement *next;
};

ListElement *createListElement(const string &word, int value, ListElement *&next)
{
	auto newElement = new ListElement{ word, value, next };
	return newElement;
}

bool isEmpty(ListElement *head)
{
	return head == nullptr;
}

int amountOfElements(ListElement *head)
{
	int count = 0;
	auto cursor = head;
	while (cursor != nullptr)
	{
		cursor = cursor->next;
		++count;
	}
	return count;
}

bool isContained(ListElement *head, const string &word)
{
	auto cursor = head;
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

void addElement(ListElement *&head, const string &word)
{
	head = createListElement(word, 1, head);
}

void increaseNumber(ListElement *&head, const string &word)
{
	auto cursor = head;
	while (cursor->word != word)
	{
		cursor = cursor->next;
	}
	++cursor->value;
}

void printList(ListElement *head)
{
	auto cursor = head;
	while (cursor != nullptr)
	{
		cout << " ' " << cursor->word << " ' (" << cursor->value << "), " << endl;
		cursor = cursor->next;
	}
}

void deleteList(ListElement *&head)
{
	while (head != nullptr)
	{
		auto toDelete = head;
		head = head->next;
		delete toDelete;
	}
	delete head;
	head = nullptr;
}





