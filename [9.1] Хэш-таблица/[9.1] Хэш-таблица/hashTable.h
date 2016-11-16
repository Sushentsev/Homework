#pragma once
#include "list.h"

struct HashTable;

HashTable *createHashTable();

int createHash(const std::string &key);
void add(HashTable *hashTable, std::string word);