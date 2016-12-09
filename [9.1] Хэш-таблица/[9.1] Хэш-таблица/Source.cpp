#include <iostream>
#include <fstream>
#include <string>
#include "hashTable.h"

void main()
{
	setlocale(LC_ALL, "Russian");

	HashTable *hashTable = createHashTable();
	std::string word = "";

	std::ifstream file("text.txt");
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

	std::cout << "������� �������������:" << std::endl;
	printHashTable(hashTable);
	
	deleteHashTable(hashTable);
}