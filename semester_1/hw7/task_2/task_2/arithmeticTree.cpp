#include <iostream>
#include <string>
#include "arithmeticTree.h"

using namespace std;

struct TreeNode
{
	int value;
	char operation;
	TreeNode *leftChild;
	TreeNode *rightChild;
	TreeNode *parent;
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

TreeNode* createTreeNode(const int value, const char &operation, TreeNode *leftChild, TreeNode *rightChild, TreeNode *parent)
{
	auto newNode = new TreeNode{ value, operation, leftChild, rightChild, parent };
	return newNode;
}

bool isDigit(const char &symbol)
{
	return (symbol >= '0'  && symbol <= '9');
}

bool isOperator(const char &symbol)
{
	return (symbol == '+' || symbol == '-' || symbol == '/' || symbol == '*');
}

bool isLeftBracket(const char &symbol)
{
	return (symbol == '(');
}

bool isRightBracket(const char &symbol)
{
	return (symbol == ')');
}

bool isEmpty(Tree *tree)
{
	return (tree->root == nullptr);
}

void buildTree(Tree *&tree, const string &expression)
{
	if (isEmpty(tree))
	{
		tree->root = createTreeNode(0, '\0', nullptr, nullptr, nullptr);
	}
	const int sizeOfExpression = expression.length();
	auto cursor = tree->root;

	for (int i = 0; i < sizeOfExpression; ++i)
	{
		if (isLeftBracket(expression[i]))
		{
			if (cursor->leftChild == nullptr)
			{
				cursor->leftChild = createTreeNode(0, '\0', nullptr, nullptr, cursor);
				cursor = cursor->leftChild;
			}
			else
			{
				cursor->rightChild = createTreeNode(0, '\0', nullptr, nullptr, cursor);
				cursor = cursor->rightChild;
			}
		}
		else if (isRightBracket(expression[i]))
		{
			cursor = cursor->parent;
		}
		else if (isDigit(expression[i]))
		{
			if (cursor->leftChild == nullptr)
			{
				cursor->leftChild = createTreeNode(atoi(expression[i]), '\0', nullptr, nullptr, cursor);
			}
			else
			{
				cursor->rightChild = createTreeNode(expression[i], '\0', nullptr, nullptr, cursor);
			}
		}
		else if (isOperator(expression[i]))
		{
			cursor->operation = expression[i];
		}
	}

	auto oldRoot = tree->root;
	tree->root = tree->root->leftChild;
	delete oldRoot;
}



double getValue(const int num1, const int num2, const char &operation)
{
	switch (operation)
	{
	case '+':
	{
		return num1 + num2;
	}
	case '-':
	{
		return num1 - num2;
	}
	case '/':
	{
		return num1 / num2;
	}
	case '*':
	{
		return num1 * num2;
	}
	default:
		break;
	}
}

double computeTree(TreeNode *node)
{
	if (node->leftChild == nullptr && node->rightChild == nullptr)
	{
		return node->value;
	}

	const int num1 = computeTree(node->leftChild);
	const int num2 = computeTree(node->rightChild);
	return getValue(num1, num2, node->value);
}

double computeTree(Tree *tree)
{
	if (isEmpty(tree))
	{
		return 0;
	}

	return computeTree(tree->root);
}

void printTree(TreeNode *node)
{
	if (node == nullptr)
	{
		return;
	}

	if (isOperator(node->value))
	{
		cout << "( " << node->value << " ";
		printTree(node->leftChild);
		printTree(node->rightChild);
		cout << ") ";
	}
	else
	{
		cout << node->value << " ";
	}
}

void printTree(Tree *tree)
{
	printTree(tree->root);
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