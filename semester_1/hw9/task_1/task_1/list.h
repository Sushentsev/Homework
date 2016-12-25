#pragma once
#include <string>

using namespace std;

/* The structure of list element */
struct ListElement;

/* Checking list on emptiness */
bool isEmpty(ListElement *head);

/* Amount of elements in a list */
int amountOfElements(ListElement *head);

/* Is a word contained */
bool isContained(ListElement *head, const string &word);

/* Adding new element in a list */
void addElement(ListElement *&head, const string &word);

/* Increasing value */
void increaseNumber(ListElement *&head, const string &word);

/* Printing list */
void printList(ListElement *head);

/* Removing list */
void deleteList(ListElement *&head);
