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
	setlocale(LC_ALL, "Russian");
	string fileName = "";
	cout << "Test: " << test() << endl << endl;
	auto hashTable = createHashTable();

	cout << "Введите названия файла: " << endl;
	cin >> fileName;
	loadFromFile(hashTable, fileName);
	cout << "Частота встречаемости:" << endl;
	printHashTable(hashTable);
	cout << "Коэффициент заполнения хеш-таблицы: " << occupancyOfHashTable(hashTable) << endl;
	cout << "Максимальная длина списка: " << maxLengthOfList(hashTable) << endl;
	cout << "Средняя длина списка: " << averageLengthOfList(hashTable) << endl;
	
	deleteHashTable(hashTable);
}