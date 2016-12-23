#pragma once
#include <string>

using namespace std;

/* The structure of element of list */
struct ListElement;

/* The strcuture of list */
struct List;

/* Creating a list */
List* createList();

/* Creating the element of list */
ListElement* createListElement(ListElement *next, const string &name, const string &phone);

/* Checking list on emptiness */
bool isEmpty(List *list);

/* Getting last element */
ListElement* getLastElement(List *list);

/* Getting name from head */
string getNameFromHead(List *list);

/* Getting phone from head */
string getPhoneFromHead(List *list);

/* Removing head */
void removeFromHead(List *&list);

/* Adding data to head */
void addToHead(List *list, const string &name, const string &phone);

/* Adding data to tale */
void addToTale(List *list, const string &name, const string &phone);

/* Getting the size of list */
int sizeOfList(List *list);

/* Printing list */
void printList(List *list);

/* Removing list */
void removeList(List *&list);