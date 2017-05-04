#include <iostream>
#include "tree.h"

using namespace std;

struct TreeNode
{
	int value;
	TreeNode *leftChild;
	TreeNode *rightChild;
};

struct Tree
{
	TreeNode *root;
};

Tree *plantTree()
{
	auto tree = new Tree{ nullptr };
	return tree;
}

TreeNode *createNewElement(TreeNode *leftChild, TreeNode *rightChild, int value)
{
	auto newNode = new TreeNode{ value, leftChild, rightChild };
	return newNode;
}

bool addNode(TreeNode *&node, int value)
{
	if (node == nullptr)
	{
		node = createNewElement(nullptr, nullptr, value);
		return true;
	}
	else if (node->value == value)
	{
		return false;
	}
	else if (value < node->value)
	{
		return addNode(node->leftChild, value);
	}
	else if (value > node->value)
	{
		return addNode(node->rightChild, value);
	}
}

bool addNode(Tree *tree, int value)
{
	return addNode(tree->root, value);
}

TreeNode *findMinNode(TreeNode *node)
{
	auto minNode = node->rightChild;
	while (minNode->leftChild != nullptr)
	{
		minNode = minNode->leftChild;
	}
	return minNode;
}

bool removeNode(TreeNode *&node, int value)
{
	if (node == nullptr)
	{
		return false;
	}
	else if (node->value == value)
	{
		if (node->leftChild == nullptr && node->rightChild == nullptr)
		{
			delete node;
			node = nullptr;
		}
		else if (node->leftChild != nullptr && node->leftChild != nullptr)
		{
			auto minNode = findMinNode(node);
			int temp = minNode->value;
			removeNode(node, temp);
			node->value = temp;
		}
		else if (node->leftChild != nullptr)
		{
			auto toDelete = node;
			node = node->leftChild;
			delete toDelete;
		}
		else if (node->rightChild != nullptr)
		{
			auto toDelete = node;
			node = node->rightChild;
			delete toDelete;
		}
		return true;
	}
	else if (value > node->value)
	{
		return removeNode(node->rightChild, value);
	}
	else if (value < node->value)
	{
		return removeNode(node->leftChild, value);
	}
}

bool removeNode(Tree *tree, int value)
{
	return removeNode(tree->root, value);
}

bool isContained(TreeNode *node, int value)
{
	if (node == nullptr)
	{
		return false;
	} 
	else if (node->value == value)
	{
		return true;
	}
	else if (value > node->value)
	{
		return isContained(node->rightChild, value);
	}
	else if (value < node->value)
	{
		return isContained(node->leftChild, value);
	}
}

bool isContained(Tree *tree, int value)
{
	return isContained(tree->root, value);
}

void printAscendingOrder(TreeNode *node)
{
	if (node == nullptr)
	{
		return;
	}
	printAscendingOrder(node->leftChild);
	cout << node->value << " ";
	printAscendingOrder(node->rightChild);
}

void printAscendingOrder(Tree *tree)
{
	printAscendingOrder(tree->root);
}

void printDescendingOrder(TreeNode *node)
{
	if (node == nullptr)
	{
		return;
	}
	printDescendingOrder(node->rightChild);
	cout << node->value << " ";
	printDescendingOrder(node->leftChild);
}

void printDescendingOrder(Tree *tree)
{
	printDescendingOrder(tree->root);
}

void removeTree(TreeNode *&node)
{
	if (node == nullptr)
	{
		return;
	}
	if (node->leftChild != nullptr)
	{
		removeTree(node->leftChild);
	}
	if (node->rightChild != nullptr)
	{
		removeTree(node->rightChild);
	}
	delete node;
	node = nullptr;
}

void removeTree(Tree *&tree)
{
	removeTree(tree->root);
	delete tree;
	tree = nullptr;
}