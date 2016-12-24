#include <iostream>
#include <string>
#include "arithmeticTree.h"

using namespace std;

struct TreeNode
{
	string value;
	TreeNode *leftChild;
	TreeNode *rightChild;
};

struct Tree
{
	TreeNode *root;
};

Tree* plantTree()
{
	auto tree = new Tree{ nullptr };
	return tree;
}

TreeNode* createTreeNode(const string &value, TreeNode *leftChild, TreeNode *rightChild)
{
	auto newNode = new TreeNode{ value, leftChild, rightChild };
	return newNode;
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
	node = nullptr
}

void removeTree(Tree *&tree)
{
	removeTree(tree->root);
	delete tree;
	tree = nullptr;
}