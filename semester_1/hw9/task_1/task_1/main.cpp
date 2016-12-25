#include <iostream>
#include <fstream>
#include <string>
#include "hashTable.h"

using namespace std;

void loadFromFile(HashTable *hashTable, const string &fileName)
{
	string word = "";
	ifstream file(fileName);
	if (file.is_open())
	{
		while (!file.eof())
		{
			file >> word;
			add(hashTable, word);
		}
		file.close();
	}
	else
	{
		cout << "Ошибка при открытии файла!" << endl;
	}
}

bool test()
{
	bool flag = true;
	auto hashTable = createHashTable();
	loadFromFile(hashTable, "test.txt");
	flag = ((occupancyOfHashTable(hashTable) == 0.06) && (maxLengthOfList(hashTable) == 2));
	deleteHashTable(hashTable);
	return flag;
}

void main()
{
	string fileName = "";
	cout << "Test: " << test() << endl << endl;
	auto hashTable = createHashTable();

	cout << "Enter file name: " << endl;
	cin >> fileName;
	loadFromFile(hashTable, fileName);
	cout << "Frequency:" << endl;
	printHashTable(hashTable);
	cout << "Hash table occupancy: " << occupancyOfHashTable(hashTable) << endl;
	cout << "Maximum size of a list: " << maxLengthOfList(hashTable) << endl;
	cout << "Average size of a list " << averageLengthOfList(hashTable) << endl;

	deleteHashTable(hashTable);
}