#pragma once
#include "list.h"

/* Описание структуры хеш-таблицы */
struct HashTable;

/* Создание хещ-таблицы */
HashTable *createHashTable();

/* Добавление слова в хеш-таблицу */
void add(HashTable *&hashTable, const std::string &word);

/* Примерная заполняемость хеш-таблицы в процентах*/
int occupancyOfHashTable(HashTable *hashTable);

/* Максимальная длина листа */
int maxLengthOfList(HashTable *hashTable);

/* Средняя длина листа */
int averageLengthOfList(HashTable *hashTable);

/* Вывод содержимого хеш-таблицы на экран */
void printHashTable(HashTable *hashTable);

/* Удаление хеш-таблицы */
void deleteHashTable(HashTable *&hashTable);