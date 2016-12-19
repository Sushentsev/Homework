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
	auto hashTable = new HashTable;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		hashTable->head[i] = nullptr;
	}
	return hashTable;
}

int getHash(const string &key)
{
	int value = 0;
	int keyLength = key.length();
	for (int i = 0; i < keyLength; ++i)
	{
		value = (value + static_cast<int>(key[i])) % sizeOfHashTable;
	}
	return value;
}

void add(HashTable *&hashTable, const string &word)
{
	int hash = getHash(word);
	if (isContained(hashTable->head[hash], word))
	{
		increaseNumber(hashTable->head[hash], word);
	}
	else
	{
		addElement(hashTable->head[hash], word);
	}
}

int occupancyOfHashTable(HashTable *hashTable)
{
	int count = 0;
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
			count += amountOfElements(hashTable->head[i]);
	}
	return (count * 100 / sizeOfHashTable);
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

int averageLengthOfList(HashTable *hashTable)
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
	return (count / amountOfList);
}

void printHashTable(HashTable *hashTable)
{
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		if (!isEmpty(hashTable->head[i]))
		{
			printList(hashTable->head[i]);
		}
	}
}

void deleteHashTable(HashTable *&hashTable)
{
	for (int i = 0; i < sizeOfHashTable; ++i)
	{
		deleteList(hashTable->head[i]);
	}
	delete hashTable;
	hashTable = nullptr;
}