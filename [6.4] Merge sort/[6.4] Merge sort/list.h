#pragma once
#include <string>

using namespace std;

struct ListElement;
struct List;
List* createList();
int getNumberByName(List *list, const string &name);
int getNumberByPhone(List *list, const string &phone);
void addToHead(List *list, const string &name, const string &phone);
void printList(List *list);
void removeList(List *&list);
