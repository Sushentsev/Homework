#pragma once
#include <string>

/* The structure of element of list */
struct ListElement;

/* The strcuture of list */
struct List;

/* Creating a list */
List* createList();

/* Creating the element of list */
ListElement* createListElement(ListElement *next, const std::string &name, const std::string &phone);

/* Checking list on emptiness */
bool isEmpty(List *list);

/* Checking whether first element is smaller than second */
bool isHeadSmaller(List *list, const short sortType);

/* Getting last element */
ListElement* getLastElement(List *list);

/* Getting name from head */
std::string getNameFromHead(List *list);

/* Getting phone from head */
std::string getPhoneFromHead(List *list);

/* Removing head */
void removeFromHead(List *&list);

/* Adding data to head */
void addToHead(List *list, const std::string &name, const std::string &phone);

/* Adding data to Tail */
void addToTail(List *list, const std::string &name, const std::string &phone);

/* Getting the size of list */
int sizeOfList(List *list);

/* Printing list */
void printList(List *list);

/* Removing list */
void removeList(List *&list);