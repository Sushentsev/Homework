#pragma once
#include "list.h"

/* �������� ��������� ���-������� */
struct HashTable;

/* �������� ���-������� */
HashTable *createHashTable();

/* ���������� ����� � ���-������� */
void add(HashTable *&hashTable, const std::string &word);

/* ��������� ������������� ���-������� � ���������*/
int occupancyOfHashTable(HashTable *hashTable);

/* ������������ ����� ����� */
int maxLengthOfList(HashTable *hashTable);

/* ������� ����� ����� */
int averageLengthOfList(HashTable *hashTable);

/* ����� ����������� ���-������� �� ����� */
void printHashTable(HashTable *hashTable);

/* �������� ���-������� */
void deleteHashTable(HashTable *&hashTable);