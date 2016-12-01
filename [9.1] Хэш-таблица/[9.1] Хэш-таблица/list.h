#pragma once

struct ListElement;

bool isEmpty(ListElement *head);
int amountOfElements(ListElement *head);
void increaseIfFoundAddOtherwise(ListElement *head, std::string word);
void printList(ListElement *head);
void deleteList(ListElement *head);
