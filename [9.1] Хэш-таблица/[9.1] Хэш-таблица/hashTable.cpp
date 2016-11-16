#include <iostream>
#include "hashTable.h"
#include "list.h"

const int sizeOfHashTable = 256;

struct HashTable
{
	ListElement *head[sizeOfHashTable];
};