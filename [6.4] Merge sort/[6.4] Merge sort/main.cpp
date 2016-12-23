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
			addToTale(book, name, phone);
		}
		file.close();
	}
	else
	{
		cout << "Error while reading file!" << endl;
	}
}

void main()
{
	auto book = createList();
	short sortType = 0;

	cout << "Choose the type of sorting (by name is 0, by phone number is 1):" << endl;
	cin >> sortType;

	loadFromFile(book);
	mergeSort(book, sortType);
	cout << "Sorted book:" << endl;
	printList(book);
	removeList(book);
}