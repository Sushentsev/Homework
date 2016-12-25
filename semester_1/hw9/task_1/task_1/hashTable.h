#pragma once
#include "list.h"

/* The structure of hash table */
struct HashTable;

/* Creating hash table */
HashTable *createHashTable();

/* Adding new word to hash table */
void add(HashTable *&hashTable, const string &word);

/* Hash table occupancy */
double occupancyOfHashTable(HashTable *hashTable);

/* Maximum size of a list */
int maxLengthOfList(HashTable *hashTable);

/* Average size of a list */
double averageLengthOfList(HashTable *hashTable);

/* Printing hash table */
void printHashTable(HashTable *hashTable);

/* Removing hash table */
void deleteHashTable(HashTable *&hashTable);