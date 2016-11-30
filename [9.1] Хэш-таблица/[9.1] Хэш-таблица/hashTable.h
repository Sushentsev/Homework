#pragma once
#include "list.h"

struct HashTable;

HashTable *createHashTable();

void add(HashTable *hashTable, std::string word);
float occupancyOfHashTable(HashTable *hashTable);
int maxLengthOfList(HashTable *hashTable);
float averageLengthOfList(HashTable *hashTable);
void deleteHashTable(HashTable *hashTable);