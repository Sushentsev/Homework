#include <iostream>
#include <fstream>
#include <string>
#include "hashTable.h"

void loadFromFile(HashTable *hashTable, const std::string &fileName)
{
	std::string word = "";
	std::ifstream file(fileName);
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
		std::cout << "������ ��� �������� �����!" << std::endl;
		return;
	}
}

bool test()
{
	bool flag = true;
	HashTable *hashTable = createHashTable();
	loadFromFile(hashTable, "test.txt");
	flag = ((occupancyOfHashTable(hashTable) == 6) && (maxLengthOfList(hashTable) == 2));
	deleteHashTable(hashTable);
	return flag;
}


void main()
{
	setlocale(LC_ALL, "Russian");

	std::cout << "Test: " << test() << std::endl;
	std::cout << "________________" << std::endl;
	HashTable *hashTable = createHashTable();
	loadFromFile(hashTable, "text.txt");
	std::cout << "������� �������������:" << std::endl;
	printHashTable(hashTable);
	std::cout << "����������� ���������� ���-�������: " << occupancyOfHashTable(hashTable) << "%" << std::endl;
	std::cout << "������������ ����� ������: " << maxLengthOfList(hashTable) << std::endl;
	std::cout << "������� ����� ������: " << averageLengthOfList(hashTable) << std::endl;
	
	deleteHashTable(hashTable);
}