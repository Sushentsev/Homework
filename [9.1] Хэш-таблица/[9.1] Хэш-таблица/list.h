#pragma once

struct ListElement;
struct List;

List *createList();
ListElement *createListElement(std::string word, int value, ListElement *next);

bool isEmpty(List *list);
void addElement(ListElement *head, std::string word, int value);
void removeElement(List *list, int value);
void deleteList(List *list);
bool increaseIfFound(ListElement *listElement, std::string word);
void printList(List *list);