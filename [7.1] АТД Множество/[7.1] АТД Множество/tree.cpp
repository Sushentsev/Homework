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
	TreeElement *newElement = new TreeElement;
	newElement->value = value;
	newElement->parent = nullptr;
	newElement->leftChild = nullptr;
	newElement->rightChild = nullptr;
	TreeElement *current = tree->root;
	if (tree->root == nullptr)
	{
		tree->root = newElement;
	}
	else while (value != current->value)
	{
		if (value < current->value)
		{
			if (current->leftChild == nullptr)
			{
				current->leftChild = newElement;
				newElement->parent = current;
				return;
			}
			current = current->leftChild;
		}
		if (value > current->value)
		{
			if (current->rightChild == nullptr)
			{
				current->rightChild = newElement;
				newElement->parent = current;
				return;
			}
			current = current->rightChild;
		}
	}
}

void deleteElement(Tree *tree, int value)
{
	TreeElement *&current = tree->root;
	if (tree->root == nullptr)
	{
		return;
	} 
	else while (value != current->value)
	{
		if (value < current->value)
		{
			current = current->leftChild;
		}
		else if (value > current->value)
		{
			current = current->rightChild;
		}
	}	
	if ((current->leftChild == nullptr) && (current->rightChild == nullptr))
	{
		delete current;
		current = nullptr;
	}
	else if ((current->leftChild != nullptr) && (current->rightChild == nullptr))
	{
		TreeElement *toDelete = current;
		current = current->leftChild;
		delete toDelete;

	}

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