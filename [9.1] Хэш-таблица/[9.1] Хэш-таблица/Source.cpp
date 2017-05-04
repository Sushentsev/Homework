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
		cout << "������ ��� �������� �����!" << endl;
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

	cout << "������� �������� �����: " << endl;
	cin >> fileName;
	loadFromFile(hashTable, fileName);
	cout << "������� �������������:" << endl;
	printHashTable(hashTable);
	cout << "����������� ���������� ���-�������: " << occupancyOfHashTable(hashTable) << endl;
	cout << "������������ ����� ������: " << maxLengthOfList(hashTable) << endl;
	cout << "������� ����� ������: " << averageLengthOfList(hashTable) << endl;
	
	deleteHashTable(hashTable);
}