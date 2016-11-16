#include <iostream>
#include <string>
#include "hashTable.h"
#include "list.h"

const int sizeOfHashTable = 64;

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
		value = (value + static_cast<int>(key[i])) % 64;
	}
	return value;
}

void add(HashTable *hashTable, std::string word)
{
	int result = createHash(word);
	if (!increaseIfFound(hashTable->head[result], word))
	{
		addElement(hashTable->head[result], word, 0);
	}
}
