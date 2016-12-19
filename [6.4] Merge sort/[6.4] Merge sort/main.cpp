#include <iostream>
#include <fstream>
#include <string>
#include "list.h"
#include "mergeSort.h"

using namespace std;

void loadFromFile(List *book)
{
	string name = "";
	string phone = "";
	ifstream file("input.txt");
	if (file.is_open())
	{
		while (!file.eof())
		{
			file >> name;
			file >> phone;
			addToHead(book, name, phone);
		}
		file.close();
	}
	else
	{
		cout << "������ ��� ������ �����!" << endl;
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	auto book = createList();
	bool sortType = 0;

	loadFromFile(book);
	//cout << "�������� ��� ���������� (�� ����� - 0, �� ������ �������� - 1):" << endl;
	//cin >> sortType;

	//printList(book);
	removeList(book);
}