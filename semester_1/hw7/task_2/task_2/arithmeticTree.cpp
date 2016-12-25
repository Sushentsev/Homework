#include "arithmeticTree.h"
#include <iostream>
#include <string>

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
	return new Tree{ nullptr };
}

TreeNode* createTreeNode(const int value, const char &operation, TreeNode *leftChild, TreeNode *rightChild, TreeNode *parent)
{
	return new TreeNode{ value, operation, leftChild, rightChild, parent };
}

bool isDigit(const char &symbol)
{
	return (symbol >= '0' && symbol <= '9');
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
		tree->root = createTreeNode(0, '0', nullptr, nullptr, nullptr);
	}

	const int sizeOfExpression = expression.length();
	int index = 0;
	auto cursor = tree->root;
	while (index < sizeOfExpression)
	{
		if (isLeftBracket(expression[index]))
		{
			if (cursor->leftChild == nullptr)
			{
				cursor->leftChild = createTreeNode(0, '0', nullptr, nullptr, cursor);
				cursor = cursor->leftChild;
			}
			else
			{
				cursor->rightChild = createTreeNode(0, '0', nullptr, nullptr, cursor);
				cursor = cursor->rightChild;
			}
		}
		else if (isRightBracket(expression[index]))
		{
			cursor = cursor->parent;
		}
		else if (isDigit(expression[index]))
		{
			int number = 0;
			while (isDigit(expression[index]))
			{
				number = number * 10 + (int)expression[index] - '0';
				++index;
			}

			if (cursor->leftChild == nullptr)
			{
				cursor->leftChild = createTreeNode(number, '0', nullptr, nullptr, cursor);
			}
			else
			{
				cursor->rightChild = createTreeNode(number, '0', nullptr, nullptr, cursor);
			}
			--index;
		}
		else if (isOperator(expression[index]))
		{
			cursor->operation = expression[index];
		}
		++index;
	}

	auto oldRoot = tree->root;
	tree->root = tree->root->leftChild;
	tree->root->parent = nullptr;
	delete oldRoot;
}

double getValue(const double num1, const double num2, const char &operation)
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

	const double num1 = computeTree(node->leftChild);
	const double num2 = computeTree(node->rightChild);
	return getValue(num1, num2, node->operation);
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

	if (isOperator(node->operation))
	{
		cout << "( " << node->operation << " ";
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
	removeTree(node->leftChild);
	removeTree(node->rightChild);
	delete node;
	node = nullptr;
}

void removeTree(Tree *&tree)
{
	removeTree(tree->root);
	delete tree;
	tree = nullptr;
}