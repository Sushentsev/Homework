#include <iostream>
#include "tree.h"

using namespace std;

void addNode(Tree *tree)
{
	int value = 0;
	cout << "Введите значение добавляемого элемента:" << endl;
	cin >> value;
	if (addNode(tree, value))
	{
		cout << "Значение успешно добавено!" << endl << endl;
	}
	else
	{
		cout << "Произошла ошибка при добавлении!" << endl << endl;
	}
}

void removeNode(Tree *tree)
{
	int value = 0;
	cout << "Введите значение удалемого элемента:" << endl;
	cin >> value;
	if (removeNode(tree, value))
	{
		cout << "Значение успешно удалено!" << endl << endl;
	}
	else
	{
		cout << "Произошла ошибка при удалении!" << endl << endl;
	}
}

void isContained(Tree *tree)
{
	int value = 0;
	cout << "Введите значение элемента для поиска:" << endl;
	cin >> value;
	if (removeNode(tree, value))
	{
		cout << "Данное значение существует в множестве!" << endl << endl;
	}
	else
	{
		cout << "Такого значения нет!" << endl << endl;
	}
}

void ascendingOrder(Tree *tree)
{
	cout << "Элементы в порядке возрастания:" << endl;
	printAscendingOrder(tree);
	cout << endl << endl;
}

void descendingOrder(Tree *tree)
{
	cout << "Элементы в порядке убывания:" << endl;
	printDescendingOrder(tree);
	cout << endl << endl;
}

void printInformation()
{
	cout << "Выберете необоходимую команду:" << endl;
	cout << "0 - Выход;" << endl;
	cout << "1 - Добавить значение;" << endl;
	cout << "2 - Удалить значение;" << endl;
	cout << "3 - Принадлежит ли значение множеству;" << endl;
	cout << "4 - Печать элементов в возрастающем порядке;" << endl;
	cout << "5 - Печать элементов в убывающем порядке;" << endl;
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