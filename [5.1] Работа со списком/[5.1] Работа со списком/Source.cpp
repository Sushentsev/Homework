#include <iostream>
#include "list.h"

void printInformation()
{
	std::cout << std::endl;
	std::cout << "�������� ��������:" << std::endl;
	std::cout << "0 � �����" << std::endl;
	std::cout << "1 � �������� �������� � ������������� ������" << std::endl;
	std::cout << "2 � ������� �������� �� ������" << std::endl;
	std::cout << "3 � ����������� ������" << std::endl;
	std::cout << std::endl;
}

void addElement(List *list)
{
	int value = 0;
	std::cout << "������� �������� ������������ ��������:" << std::endl;
	std::cin >> value;
	addElement(list, value);
	std::cout << "������� ������� ��������!" << std::endl;
}

void removeElement(List *list)
{
	int value = 0;
	std::cout << "������� �������� ���������� ��������:" << std::endl;
	std::cin >> value;
	if (removeElement(list, value))
		std::cout << "�������� �������� ������ �������!" << std::endl;
	else
		std::cout << "������ ��� ��������!" << std::endl;
}

bool test(List *list)
{
	bool result = true;
	addElement(list, 0);
	addElement(list, -1);
	addElement(list, 1);
	return result;
}

void main()
{

	setlocale(LC_ALL, "Russian");
	List *list = createList();
	std::cout << test(list) << std::endl;
	deleteList(list)

	List *list = createList();
	short selection = -1;

	while (selection != 0)
	{
		printInformation();
		std::cin >> selection;
		switch (selection)
		{
		case 1:
			addElement(list);
			break;
		case 2:
			removeElement(list);
			break;
		case 3:
			printList(list);
			break;
		default:
			break;
		}
	}

	deleteList(list);
}