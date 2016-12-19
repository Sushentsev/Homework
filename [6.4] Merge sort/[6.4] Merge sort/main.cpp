#include <iostream>
#include <fstream>
#include <string>
#include "list.h"

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
		cout << "Ошибка при чтении файла!" << endl;
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	auto book = createList();
	loadFromFile(book);
	printList(book);
	removeList(book);
}