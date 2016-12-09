#pragma once

/* �������� ��������� �������� */
struct ListElement;

/* ��������, �������� �� ������ ������ (true, ���� ����, ����� false) */
bool isEmpty(ListElement *head);

/* ���������� ��������� � ������ */
int amountOfElements(ListElement *head);

/* ��������, ����������� �� ������� � ������ */
bool isContained(ListElement *head, const std::string &word);

/* ���������� �������� � ������ */
void addElement(ListElement *head, const std::string &word);

/* ���������� �������� (���������� ������������� � ������) �������� */
void increaseNumber(ListElement *head, const std::string &word);

/* ����� ������ �� ����� */
void printList(ListElement *head);

/* ������ �������� ������ */
void deleteList(ListElement *head);
