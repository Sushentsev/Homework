#pragma once
#include <string>

using namespace std;

/* The structure of ListElement */
struct ListElement;

/* The structure of List */
struct List;

/* Creating list */
List* createList();

ListElement* getLastElement(List *list);

string getNameFromHead(List *list);

string getPhoneFromHead(List *list);

void addToTale(List *list, const string &name, const string &phone);

void removeFromHead(List *&list);

/* Getting size of list */
int getSize(List *list);

/* Adding value to head */
void addToHead(List *list, const string &name, const string &phone);

/* Printing list */
void printList(List *list);

/* Removing  list */
void removeList(List *&list);
