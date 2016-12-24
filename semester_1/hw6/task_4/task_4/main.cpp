#include <iostream>
#include <fstream>
#include <string>
#include "list.h"
#include "mergeSort.h"

using namespace std;

void loadFromFile(List *book, const string &fileName)
{
	string name = "";
	string phone = "";
	ifstream file(fileName);
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

bool isSorted(List *list, const short sortType)
{
	const int size = sizeOfList(list);
	bool flag = true;

	while (!isEmpty(list))
	{
		if (sortType == 1) //sort by phone
		{
			flag = flag && isSmaller(list, 1);
			removeFromHead(list);
		}
		else if (sortType == 0) //sort by name
		{
			flag = flag && isSmaller(list, 0);
			removeFromHead(list);
		}
	}

	return flag;
}

bool test1()
{
	auto book = createList();
	const string fileName = "test.txt";
	const short sortType = 0;
	bool flag = true;
	loadFromFile(book, fileName);
	mergeSort(book, sortType);
	flag = isSorted(book, sortType);
	removeList(book);

	return flag;
}

bool test2()
{
	auto book = createList();
	const string fileName = "test.txt";
	const short sortType = 1;
	bool flag = true;
	loadFromFile(book, fileName);
	mergeSort(book, sortType);
	flag = isSorted(book, sortType);
	removeList(book);

	return flag;
}

void main()
{
	auto book = createList();
	short sortType = 0;
	string fileName = "";

	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;

	cout << "Input file name:" << endl;
	cin >> fileName;
	cout << "Choose the type of sorting (by name is 0, by phone number is 1):" << endl;
	cin >> sortType;

	loadFromFile(book, fileName);
	mergeSort(book, sortType);
	cout << "Sorted book:" << endl;
	printList(book);
	removeList(book);
}