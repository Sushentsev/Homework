#pragma once

struct ListElement;
struct List;

void addElement(List *list, std::string word, int value);
void increaseIfFoundAddOtherwise(List *list, std::string word);
void deleteList(List *list);