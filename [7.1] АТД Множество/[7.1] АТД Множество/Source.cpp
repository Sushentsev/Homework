#include <iostream>
#include "tree.h"

void addNode(Tree *tree)
{
	int value = 0;
	std::cout << "������� �������� ������������ ��������:" << std::endl;
	std::cin >> value;
	if (addNode(tree, value))
	{
		std::cout << "�������� ������� ��������!" << std::endl;
	}
	else
	{
		std::cout << "��������� ������ ��� ����������!" << std::endl;
	}
	std::cout << std::endl;
}

void removeNode(Tree *tree)
{
	int value = 0;
	std::cout << "������� �������� ��������� ��������:" << std::endl;
	std::cin >> value;
	if (removeNode(tree, value))
	{
		std::cout << "�������� ������� �������!" << std::endl;
	}
	else
	{
		std::cout << "��������� ������ ��� ��������!" << std::endl;
	}
	std::cout << std::endl;
}

void isContained(Tree *tree)
{
	int value = 0;
	std::cout << "������� �������� �������� ��� ������:" << std::endl;
	std::cin >> value;
	if (removeNode(tree, value))
	{
		std::cout << "������ �������� ���������� � ���������!" << std::endl;
	}
	else
	{
		std::cout << "������ �������� ���!" << std::endl;
	}
	std::cout << std::endl;
}

void AscendingOrder(Tree *tree)
{
	std::cout << "�������� � ������� �����������:" << std::endl;
	printAscendingOrder(tree);
	std::cout << std::endl << std::endl;
}

void DescendingOrder(Tree *tree)
{
	std::cout << "�������� � ������� ��������:" << std::endl;
	printDescendingOrder(tree);
	std::cout << std::endl << std::endl;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	Tree *tree = plantTree();
	int selection = -1;

	while (selection)
	{
		std::cout << "�������� ������������ �������:" << std::endl;
		std::cout << "0 - �����;" << std::endl;
		std::cout << "1 - �������� ��������;" << std::endl;
		std::cout << "2 - ������� ��������;" << std::endl;
		std::cout << "3 - ����������� �� �������� ���������;" << std::endl;
		std::cout << "4 - ������ ��������� � ������������ �������;" << std::endl;
		std::cout << "5 - ������ ��������� � ��������� �������;" << std::endl;
		std::cout << std::endl;
		std::cin >> selection;

		switch (selection)
		{
		case 1:
			addNode(tree);
			break;
		case 2:
			removeNode(tree);
			break;
		case 3:
			isContained(tree);
			break;
		case 4:
			AscendingOrder(tree);
			break;
		case 5:
			DescendingOrder(tree);
			break;
		default:
			break;
		}
	}
	removeTree(tree);
	delete tree;
}