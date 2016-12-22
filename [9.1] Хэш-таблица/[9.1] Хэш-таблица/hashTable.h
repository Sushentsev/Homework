#pragma once
#include "list.h"

/* �������� ��������� ���-������� */
struct HashTable;

/* �������� ���-������� */
HashTable *createHashTable();

/* ���������� ����� � ���-������� */
void add(HashTable *&hashTable, const string &word);

/* ��������� ������������� ���-������� � ���������*/
double occupancyOfHashTable(HashTable *hashTable);

/* ������������ ����� ����� */
int maxLengthOfList(HashTable *hashTable);

/* ������� ����� ����� */
double averageLengthOfList(HashTable *hashTable);

/* ����� ����������� ���-������� �� ����� */
void printHashTable(HashTable *hashTable);

/* �������� ���-������� */
void deleteHashTable(HashTable *&hashTable);