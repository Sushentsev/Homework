#pragma once
#include "list.h"

struct HashTable;

HashTable *createHashTable();

void add(HashTable *hashTable, const std::string &word);
float occupancyOfHashTable(HashTable *hashTable);
int maxLengthOfList(HashTable *hashTable);
float averageLengthOfList(HashTable *hashTable);
void printHashTable(HashTable *hashTable);
void deleteHashTable(HashTable *hashTable);