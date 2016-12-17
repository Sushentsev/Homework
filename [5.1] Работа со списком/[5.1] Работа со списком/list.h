#pragma once

/* Структура списка */
struct List;

/* Структура элемента списка */
struct ListElement;

/* Создание списка */
List* createList();

/* Добавление нового элемента в сортированный список */
void addElement(List *list, int value);

/* Удаление элемента из сортированнового списка */
bool removeElement(List *list, int value);

/* Получить значение по номеру элемента */
int getValue(List *list, int number);

/* Печать списка */
void printList(List *list);

/* Удаление списка */
void deleteList(List *&list);