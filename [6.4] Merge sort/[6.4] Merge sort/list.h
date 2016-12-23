#pragma once
#include <string>

using namespace std;

struct ListElement;
struct List;

List* createList();

ListElement* createListElement(ListElement *next, const string &name, const string &phone);

bool isEmpty(List *list);

ListElement* getLastElement(List *list);

string getNameFromHead(List *list);

string getPhoneFromHead(List *list);

void removeFromHead(List *&list);

void addToHead(List *list, const string &name, const string &phone);

void addToTale(List *list, const string &name, const string &phone);

int getSize(List *list);

void printList(List *list);

void removeList(List *&list);