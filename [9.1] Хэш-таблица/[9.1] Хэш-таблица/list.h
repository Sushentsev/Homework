#pragma once

/* Описание структуры элемента */
struct ListElement;

/* Проверка, является ли список пустым (true, если пуст, иначе false) */
bool isEmpty(ListElement *head);

/* Количество элементов в списке */
int amountOfElements(ListElement *head);

/* Проверка, присутсвует ли элимент в списке */
bool isContained(ListElement *head, const std::string &word);

/* Добавление элемента в список */
void addElement(ListElement *head, const std::string &word);

/* Увеличение значения (количество встречаемости в тексте) элемента */
void increaseNumber(ListElement *head, const std::string &word);

/* Вывод списка на экран */
void printList(ListElement *head);

/* Полное удаление списка */
void deleteList(ListElement *head);
