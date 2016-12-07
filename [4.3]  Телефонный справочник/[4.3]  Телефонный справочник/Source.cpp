#include <iostream>
#include <fstream>
#include <string>

struct phoneBook
{
	char name[30] = "";
	char phone[15] = "";
};

void addRecord(int numberOfRecords, phoneBook book[])
{
	std::cout << "Введите имя" << std::endl;
	std::cin >> book[numberOfRecords].name;
	std::cout << "Введите телефон" << std::endl;
	std::cin >> book[numberOfRecords].phone;
	std::cout << "Запись успешно добавлена!" << std::endl;
	std::cout << std::endl;
}

void printRecords(int numberOfRecords, phoneBook book[])
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		std::cout << book[i].name << " " << book[i].phone << std::endl;
	}
	std::cout << std::endl;
}

void findPhone(int numberOfRecords, phoneBook book[])
{
	char name[30];
	std::cout << "Введите имя" << std::endl;
	std::cin >> name;
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (strcmp(name, book[i].name) == 0)
		{
			std::cout << book[i].phone << std::endl;
		}
	}
	std::cout << std::endl;
}

void findName(int numberOfRecords, phoneBook book[])
{
	char phone[30];
	std::cout << "Введите телефон" << std::endl;
	std::cin >> phone;
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (strcmp(phone, book[i].phone) == 0)
		{
			std::cout << book[i].name << std::endl;
		}
	}
	std::cout << std::endl;
}

void saveToFile(int initialNumberOfRecords, int currentNumberOfRecords, phoneBook book[])
{
	std::ofstream file("phonebook.txt", std::ios_base::app);
	for (int i = initialNumberOfRecords; i < currentNumberOfRecords; ++i)
	{
		file << book[i].name << " " << book[i].phone << std::endl;
	}
	std::cout << "Текущие данные успешно сохранены в файл!" << std::endl;
	std::cout << std::endl;
	file.close();
}

void printInformation()
{
	std::cout << "Выберете необходимую операцию:" << std::endl;
	std::cout << "0 - выйти" << std::endl;
	std::cout << "1 - добавить запись(имя и телефон)" << std::endl;
	std::cout << "2 - распечатать все имеющиеся записи" << std::endl;
	std::cout << "3 - найти телефон по имени" << std::endl;
	std::cout << "4 - найти имя по телефону" << std::endl;
	std::cout << "5 - сохранить текущие данные в файл" << std::endl;
	std::cout << std::endl;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int selection = 1;
	int initialNumberOfRecords = 0;
	int currentNumberOfRecords = 0;
	char record[100];
	phoneBook book[100];
	std::ifstream file("phonebook.txt");
	if (file.is_open())
	{
		while (!file.eof())
		{
			++initialNumberOfRecords;
			file >> book[initialNumberOfRecords - 1].name;
			file >> book[initialNumberOfRecords - 1].phone;
		}
		file.close();
		currentNumberOfRecords = initialNumberOfRecords;
	}
	else
	{
		file.close();
		std::ofstream file("phonebook.txt");
		file.close();
	}

	while (selection != 0)
	{
		printInformation();
		std::cin >> selection;
		std::cout << std::endl;
		switch (selection)
		{
		case 1:
			if (currentNumberOfRecords != 100)
			{
				addRecord(currentNumberOfRecords, book);
				++currentNumberOfRecords;
			}
			else
				std::cout << "База полностью заполнена!" << std::endl;
			break;
		case 2:
			printRecords(currentNumberOfRecords, book);
			break;
		case 3:
			findPhone(currentNumberOfRecords, book);
			break;
		case 4:
			findName(currentNumberOfRecords, book);
			break;
		case 5:
			saveToFile(initialNumberOfRecords, currentNumberOfRecords, book);
			currentNumberOfRecords = initialNumberOfRecords;
			break;
		default:
			break;
		}
	}
}