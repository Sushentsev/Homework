#include <iostream>
#include "tree.h"

using namespace std;

void addNode(Tree *tree)
{
	int value = 0;
	cout << "������� �������� ������������ ��������:" << endl;
	cin >> value;
	if (addNode(tree, value))
	{
		cout << "�������� ������� ��������!" << endl << endl;
	}
	else
	{
		cout << "��������� ������ ��� ����������!" << endl << endl;
	}
}

void removeNode(Tree *tree)
{
	int value = 0;
	cout << "������� �������� ��������� ��������:" << endl;
	cin >> value;
	if (removeNode(tree, value))
	{
		cout << "�������� ������� �������!" << endl << endl;
	}
	else
	{
		cout << "��������� ������ ��� ��������!" << endl << endl;
	}
}

void isContained(Tree *tree)
{
	int value = 0;
	cout << "������� �������� �������� ��� ������:" << endl;
	cin >> value;
	if (removeNode(tree, value))
	{
		cout << "������ �������� ���������� � ���������!" << endl << endl;
	}
	else
	{
		cout << "������ �������� ���!" << endl << endl;
	}
}

void ascendingOrder(Tree *tree)
{
	cout << "�������� � ������� �����������:" << endl;
	printAscendingOrder(tree);
	cout << endl << endl;
}

void descendingOrder(Tree *tree)
{
	cout << "�������� � ������� ��������:" << endl;
	printDescendingOrder(tree);
	cout << endl << endl;
}

void printInformation()
{
	cout << "�������� ������������ �������:" << endl;
	cout << "0 - �����;" << endl;
	cout << "1 - �������� ��������;" << endl;
	cout << "2 - ������� ��������;" << endl;
	cout << "3 - ����������� �� �������� ���������;" << endl;
	cout << "4 - ������ ��������� � ������������ �������;" << endl;
	cout << "5 - ������ ��������� � ��������� �������;" << endl;
	cout << endl;
}

bool test()
{
	bool flag = true;
	Tree *tree = plantTree();
	addNode(tree, 5);
	addNode(tree, 8);
	addNode(tree, 10);
	addNode(tree, 7);
	addNode(tree, -5);
	addNode(tree, -3);
	flag = flag && (isContained(tree, 8) == 1) && (isContained(tree, -5) == 1) && (isContained(tree, -10) == 0);
	removeNode(tree, 10);
	removeNode(tree, -5);
	flag = flag && (isContained(tree, 10) == 0) && (isContained(tree, -3) == 1);
	removeTree(tree);
	return flag;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Test: " << test() << endl;
 	auto tree = plantTree();
	int selection = -1;

	while (selection)
	{
		printInformation();
		cin >> selection;
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
			ascendingOrder(tree);
			break;
		case 5:
			descendingOrder(tree);
			break;
		default:
			break;
		}
	}
	removeTree(tree);
	delete tree;
}