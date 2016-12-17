#pragma once

/* ��������� ������ */
struct List;

/* ��������� �������� ������ */
struct ListElement;

/* �������� ������ */
List* createList();

/* ���������� ������ �������� � ������������� ������ */
void addElement(List *list, int value);

/* �������� �������� �� ���������������� ������ */
bool removeElement(List *list, int value);

/* �������� �������� �� ������ �������� */
int getValue(List *list, int number);

/* ������ ������ */
void printList(List *list);

/* �������� ������ */
void deleteList(List *&list);