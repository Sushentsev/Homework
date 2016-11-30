#include <iostream>
#include <string>
#include "hashTable.h"
#include "list.h"

const int sizeOfHashTable = 101; //the smallest prime number with three digits

struct HashTable
{
	ListElement *head[sizeOfHashTable];
};

HashTable *createHashTable()
{
	HashTable *hashTable = new HashTable;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		hashTable->head[i] = nullptr;
	}
	return hashTable;
}

int createHash(const std::string &key)
{
	int value = 0;
	for (int i = 0; i < key.length(); ++i)
	{
		value = (value + static_cast<int>(key[i])) % (sizeOfHashTable);
	}
	return value;
}

void add(HashTable *hashTable, std::string word)
{
	
}
