#pragma once

struct ListElement;
struct List;

List *createList();
ListElement *createListElement(int value, ListElement *next);

bool isEmpty(List *list);
void addElement(List *list, int value);
void removeElement(List *list, int value);
void deleteList(List *list);
void printList(List *list);