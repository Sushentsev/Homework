#include <iostream>
#include "tree.h"

void addNode(Tree *tree)
{
	int value = 0;
	std::cout << "Введите значение добавляемого элемента:" << std::endl;
	std::cin >> value;
	if (addNode(tree, value))
	{
		std::cout << "Значение успешно добавено!" << std::endl;
	}
	else
	{
		std::cout << "Произошла ошибка при добавлении!" << std::endl;
	}
	std::cout << std::endl;
}

void removeNode(Tree *tree)
{
	int value = 0;
	std::cout << "Введите значение удалемого элемента:" << std::endl;
	std::cin >> value;
	if (removeNode(tree, value))
	{
		std::cout << "Значение успешно удалено!" << std::endl;
	}
	else
	{
		std::cout << "Произошла ошибка при удалении!" << std::endl;
	}
	std::cout << std::endl;
}

void isContained(Tree *tree)
{
	int value = 0;
	std::cout << "Введите значение элемента для поиска:" << std::endl;
	std::cin >> value;
	if (removeNode(tree, value))
	{
		std::cout << "Данное значение существует в множестве!" << std::endl;
	}
	else
	{
		std::cout << "Такого значения нет!" << std::endl;
	}
	std::cout << std::endl;
}

void AscendingOrder(Tree *tree)
{
	std::cout << "Элементы в порядке возрастания:" << std::endl;
	printAscendingOrder(tree);
	std::cout << std::endl << std::endl;
}

void DescendingOrder(Tree *tree)
{
	std::cout << "Элементы в порядке убывания:" << std::endl;
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
		std::cout << "Выберете необоходимую команду:" << std::endl;
		std::cout << "0 - Выход;" << std::endl;
		std::cout << "1 - Добавить значение;" << std::endl;
		std::cout << "2 - Удалить значение;" << std::endl;
		std::cout << "3 - Принадлежит ли значение множеству;" << std::endl;
		std::cout << "4 - Печать элементов в возрастающем порядке;" << std::endl;
		std::cout << "5 - Печать элементов в убывающем порядке;" << std::endl;
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