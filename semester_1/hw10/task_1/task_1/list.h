#pragma once

/* The structure of list element */
struct ListElement;

/* Getting value from list element */
int getValue(ListElement *element);

/* Pointer to next element */
ListElement *nextElement(ListElement *element);

/* Checking if value is contained */
bool isContained(ListElement *head, int value);

/* Checking list on emptiness */
bool isEmpty(ListElement *head);

/* Adding value to head */
void addToHead(ListElement *&head, int value);

/* Printing list */
void printList(ListElement *head);

/* Removing list */
void removeList(ListElement *&head);