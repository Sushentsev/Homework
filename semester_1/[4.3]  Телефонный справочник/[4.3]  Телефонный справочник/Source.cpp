#include <iostream>
#include <fstream>
#include <string>

struct PhoneBook
{
	std::string name;
	std::string phone;
};

void loadFromFile(PhoneBook book[], int &initialNumberOfRecords, int &currentNumberOfRecords)
{
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
}

bool isNameContained(PhoneBook book[], int numberOfRecords, const std::string &name)
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (book[i].name == name)
		{
			return true;
		}
	}
	return false;
}

bool isPhoneContained(PhoneBook book[], int numberOfRecords, const std::string &phone)
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (book[i].phone == phone)
		{
			return true;
		}
	}
	return false;
}

void addRecord(PhoneBook book[], int &numberOfRecords, const std::string &name, const std::string &phone)
{
	book[numberOfRecords].name = name;
	book[numberOfRecords].phone = phone;
	++numberOfRecords;
}

void printRecords(PhoneBook book[], int numberOfRecords)
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		std::cout << book[i].name << " " << book[i].phone << std::endl;
	}
	std::cout << std::endl;
}

void findPhone(PhoneBook book[], int numberOfRecords, const std::string &name)
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (name == book[i].name)
		{
			std::cout << book[i].phone << std::endl;
			std::cout << std::endl;
			return;
		}
	}
}

void findName(PhoneBook book[], int numberOfRecords, const std::string &phone)
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (phone == book[i].phone)
		{
			std::cout << book[i].name << std::endl;
			std::cout << std::endl;
			return;
		}
	}
	return;
}

void saveToFile(PhoneBook book[], int initialNumberOfRecords, int currentNumberOfRecords)
{
	std::ofstream file("phonebook.txt", std::ios_base::app);
	for (int i = initialNumberOfRecords; i < currentNumberOfRecords; ++i)
	{
		file << book[i].name << " " << book[i].phone << std::endl;
	}
	std::cout << "������� ������ ������� ��������� � ����!" << std::endl;
	std::cout << std::endl;
	file.close();
}

void printInformation()
{
	std::cout << "�������� ����������� ��������:" << std::endl;
	std::cout << "0 - �����" << std::endl;
	std::cout << "1 - �������� ������(��� � �������)" << std::endl;
	std::cout << "2 - ����������� ��� ��������� ������" << std::endl;
	std::cout << "3 - ����� ������� �� �����" << std::endl;
	std::cout << "4 - ����� ��� �� ��������" << std::endl;
	std::cout << "5 - ��������� ������� ������ � ����" << std::endl;
	std::cout << std::endl;
}

void selectOperation(PhoneBook book[], int &currentNumberOfRecords, int &initialNumberOfRecords)
{
	std::string name = "";
	std::string phone = "";
	int selection = -1;
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
				std::cout << "������� ���:" << std::endl;
				std::cin >> name;
				std::cout << "������� �������:" << std::endl;
				std::cin >> phone;
				addRecord(book, currentNumberOfRecords, name, phone);
				std::cout << "������ ������� ���������!" << std::endl;
			}
			else
				std::cout << "���� ��������� ���������!" << std::endl;
			break;
		case 2:
			printRecords(book, currentNumberOfRecords);
			break;
		case 3:
			std::cout << "������� ���:" << std::endl;
			std::cin >> name;
			if (isNameContained(book, currentNumberOfRecords, name))
			{
				findPhone(book, currentNumberOfRecords, name);
			}
			else
			{
				std::cout << "��� �� �������!" << std::endl;
			}
			break;
		case 4:
			std::cout << "������� �������:" << std::endl;
			std::cin >> phone;
			if (isPhoneContained(book, currentNumberOfRecords, phone))
			{
				findName(book, currentNumberOfRecords, phone);
			}
			else
			{
				std::cout << "������� �� ������!" << std::endl;
			}
			break;
		case 5:
			saveToFile(book, initialNumberOfRecords, currentNumberOfRecords);
			currentNumberOfRecords = initialNumberOfRecords;
			break;
		default:
			break;
		}
	}
}

bool test()
{
	bool flag = 1;
	int numberOfRecords = 0;
	PhoneBook book[100];
	addRecord(book, numberOfRecords, "Misha", "12345");
	addRecord(book, numberOfRecords, "Sasha", "123456");
	addRecord(book, numberOfRecords, "Dasha", "1234567");
	flag = (book[0].name == "Misha") && (book[2].phone == "1234567") && (isPhoneContained(book, numberOfRecords, "123") == 0)
		&& (isPhoneContained(book, numberOfRecords, "123456") == 1) && (isNameContained(book, numberOfRecords, "Dima") == 0)
		&& (isNameContained(book, numberOfRecords, "Sasha") == 1);
	return flag;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int initialNumberOfRecords = 0;
	int currentNumberOfRecords = 0;
	PhoneBook book[100];
	std::cout << "Test: " << test() << std::endl;
	loadFromFile(book, initialNumberOfRecords, currentNumberOfRecords);
	selectOperation(book, currentNumberOfRecords, initialNumberOfRecords);
}