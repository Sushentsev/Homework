#pragma once
#include <string>

using namespace std;

/* �������� ��������� �������� */
struct ListElement;

/* ��������, �������� �� ������ ������ (true, ���� ����, ����� false) */
bool isEmpty(ListElement *head);

/* ���������� ��������� � ������ */
int amountOfElements(ListElement *head);

/* ��������, ����������� �� ������� � ������ */
bool isContained(ListElement *head, const string &word);

/* ���������� �������� � ������ */
void addElement(ListElement *&head, const string &word);

/* ���������� �������� (���������� ������������� � ������) �������� */
void increaseNumber(ListElement *&head, const string &word);

/* ����� ������ �� ����� */
void printList(ListElement *head);

/* ������ �������� ������ */
void deleteList(ListElement *&head);
