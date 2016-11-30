#include <iostream>
#include <string>
#include "hashTable.h"
#include "list.h"

const int sizeOfHashTable = 100;

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

int getHash(const std::string &key)
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
	int hash = getHash(word);
	increaseIfFoundAddOtherwise(hashTable->head[hash]);
}

float occupancyOfHashTable(HashTable *hashTable)
{
	int count = 0;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		if (!isEmpty(hashTable->head[i]))
		{
			count += amountOfElements(hashTable->head[i]);
		}
	}
	return count / sizeOfHashTable;
}

int maxLengthOfList(HashTable *hashTable)
{
	int count = 0;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		if (count < amountOfElements(hashTable->head[i]))
		{
			count = amountOfElements(hashTable->head[i]);
		}
	}
	return count;
}

float averageLengthOfList(HashTable *hashTable)
{
	int count = 0;
	int amountOfList = 0;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		if (!isEmpty(hashTable->head[i]))
		{
			count += amountOfElements(hashTable->head[i]);
			++amountOfList;
		}
	}
	return count / amountOfList;
}
