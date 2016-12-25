#pragma once

/* The structure of list element */
struct ListElement;

/* The structure of list */
struct List;

/* Creating list */
List *createList();

/* Checking list on emptiness */
bool isEmpty(List *list);

/* Creating squad */
void createSquad(List *&list, const int n);

/* Removing element */
void removeElement(ListElement *&head, ListElement *&previousElement);

/* Getting the number of survior */
int survivor(List *&list, const int m);

/* Removing list */
void removeList(List *&list);