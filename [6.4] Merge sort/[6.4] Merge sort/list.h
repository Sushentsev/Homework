#pragma once
#include <string>

using namespace std;

struct ListElement;
struct List;
List* createList();
void addToHead(List *list, const string &name, const string &phone);
void printList(List *list);
void removeList(List *&list);
