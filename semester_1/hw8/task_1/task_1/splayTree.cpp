#include <iostream>
#include <string>

using namespace std;

struct Element
{
	string key;
	string value;
};

struct TreeNode
{
	Element *value;
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

TreeNode* createTreeNode(const string &key, const string &value, TreeNode *leftChild, TreeNode *rightChild, TreeNode *parent)
{
	auto newValue = new Element{ key, value };
	auto newNode = new TreeNode{ newValue, leftChild, rightChild, parent };
	return newNode;
}

void zig(TreeNode *&node)
{

}

void zigZag(TreeNode *&node)
{

}

void zigZig(TreeNode *&node)
{

}

void splay(Tree *tree)
{

}

string getNodeValue(TreeNode *node, const string &key)
{
	if (node->value->key == key)
	{
		return node->value->value;
	}
	else if (node->leftChild == nullptr && node->rightChild == nullptr)
	{
		//will be splaying
		return "";
	}
	else if (key < node->value->key)
	{
		return getNodeValue(node->leftChild, key);
	}
	else if (key > node->value->key)
	{
		return getNodeValue(node->rightChild, key);
	}
}

string getValue(Tree *tree, const string &key)
{
	return getNodeValue(tree->root, key);
}

bool isContained(TreeNode *node, const string &key)
{
	if (node->value->key == key)
	{
		return true;
	}
	else if (node->leftChild == nullptr && node->rightChild == nullptr)
	{
		//will be splaying
		return "";
	}
	else if (key < node->value->key)
	{
		return isContained(node->leftChild, key);
	}
	else if (key > node->value->key)
	{
		return isContained(node->rightChild, key);
	}
}

bool isContained(Tree *tree, const string &key)
{
	return isContained(tree->root, key);
}

void addValue(Tree *tree, const string &key, const string &value)
{

}

void removeValue(Tree *tree, const string &key)
{

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