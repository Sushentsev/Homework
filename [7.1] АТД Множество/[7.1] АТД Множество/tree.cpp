#include <iostream>
#include "tree.h"

struct TreeElement
{
	int value;
	TreeElement *parent;
	TreeElement *leftChild;
	TreeElement *rightChild;
};

struct Tree
{
	TreeElement *root;
};

Tree* plantTree()
{
	Tree *tree = new Tree;
	tree->root = nullptr;
	return tree;
}

void addElement(Tree *tree, int value)
{

}

void deleteElement(Tree *tree, int value)
{

}

bool isContained(Tree *tree, int value)
{
	TreeElement *current = tree->root;
	if (tree->root == nullptr)
	{
		return 0;
	}
	else while (current != nullptr)
	{
		if (value == current->value)
		{
			return 1;
		}
		else if (value < current->value)
		{
			current = current->leftChild;
		}
		else if (value > current->value)
		{
			current = current->rightChild;
		}
	}
	return 0;
}

void printAscendingOrder(Tree *tree)
{

}

void printDescendingOrder(Tree *tree)
{

}