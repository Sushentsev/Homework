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

TreeNode* getParent(TreeNode *node)
{
	if (node->parent == nullptr)
	{
		return nullptr;
	}
	return node->parent;
}

bool isEmpty(Tree *tree)
{
	return (tree->root == nullptr);
}

void turnRight(TreeNode *&child, TreeNode *&parent)
{
	parent->leftChild = child->rightChild;
	child->parent = parent->parent;
	parent->parent = child;
	child->rightChild = parent;
}

void turnLeft(TreeNode *&child, TreeNode *&parent)
{
	parent->rightChild = child->leftChild;
	child->parent = parent->parent;
	parent->parent = child;
	child->leftChild = parent;
}

void zig(TreeNode *&child, TreeNode *&parent)
{
	if (parent->leftChild == child)
	{
		turnRight(child, parent);
	}
	else if (parent->rightChild == child)
	{
		turnLeft(child, parent);
	}
}

void zigZag(TreeNode *&child, TreeNode *&parent)
{
	if (parent->leftChild == child)
	{
		turnRight(child, parent);
		turnLeft(child, child->parent);
	}
	else if (parent->rightChild == child)
	{
		turnLeft(child, parent);
		turnRight(child, child->parent);
	}
}

void zigZig(TreeNode *&child, TreeNode *&parent)
{
	if (parent->leftChild == child)
	{
		turnRight(parent, parent->parent);
		turnRight(child, parent);
	}
	else if (parent->rightChild == child)
	{
		turnLeft(parent, parent->parent);
		turnLeft(child, parent);
	}
}

bool isRoot(TreeNode *node)
{
	return (node->parent == nullptr);
}

bool isBothLeftChildren(TreeNode *child, TreeNode *parent)
{
	return (parent->leftChild == child && parent->parent->leftChild == parent);
}

bool isBothRightChildren(TreeNode *child, TreeNode *parent)
{
	return (parent->rightChild == child && parent->parent->rightChild == parent);
}

void splay(TreeNode *&node)
{
	if (node == nullptr)
	{
		return;
	}

	while (!isRoot(node))
	{
		if (isRoot(node->parent))
		{
			zig(node, node->parent);
		}
		else if (isBothLeftChildren(node, node->parent) || isBothRightChildren(node, node->parent))
		{
			zigZig(node, node->parent);
		}
		else
		{
			zigZag(node, node->parent);
		}
	}
}

string getValue(TreeNode *&node, const string &key)
{
	if (node->value->key == key)
	{
		splay(node);
		return node->value->value;
	}
	else if (node->leftChild == nullptr && node->rightChild == nullptr)
	{
		splay(node);
		return "";
	}
	else if (key < node->value->key)
	{
		return getValue(node->leftChild, key);
	}
	else if (key > node->value->key)
	{
		return getValue(node->rightChild, key);
	}
}

string getValue(Tree *tree, const string &key)
{
	if (isEmpty(tree))
	{
		return "";
	}
	return getValue(tree->root, key);
}

bool isContained(TreeNode *&node, const string &key)
{
	if (node->value->key == key)
	{
		splay(node);
		return true;
	}
	else if (node->leftChild == nullptr && node->rightChild == nullptr)
	{
		splay(node);
		return false;
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
	if (isEmpty(tree))
	{
		return false;
	}
	return isContained(tree->root, key);
}

void addNode(TreeNode *&node, const string &key, const string &value)
{

	auto parent = node->parent;
	if (node == nullptr)
	{
		node = createTreeNode(key, value, nullptr, nullptr, parent);
		splay(node);
		return;
	}
	else if (node->value->key == key)
	{
		node->value->value = value;
		splay(node);
		return;
	}
	else if (key < node->value->key)
	{
		return addNode(node->leftChild, key, value);
	}
	else if (key > node->value->key)
	{
		return addNode(node->rightChild, key, value);
	}
}

void addNode(Tree *tree, const string &key, const string &value)
{
	if (isEmpty(tree))
	{
		tree->root = createTreeNode(key, value, nullptr, nullptr, nullptr);
		return;
	}

	addNode(tree->root, key, value);
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

bool hasBothChildren(TreeNode *node)
{
	return (node->leftChild != nullptr && node->rightChild != nullptr);
}

bool hasNotChildren(TreeNode *node)
{
	return (node->leftChild == nullptr && node->rightChild == nullptr);
}

bool hasOnlyLeftChild(TreeNode *node)
{
	return (node->leftChild != nullptr && node->rightChild == nullptr);
}

bool hasOnlyRightChild(TreeNode *node)
{
	return (node->leftChild == nullptr && node->rightChild != nullptr);
}

void removeNode(TreeNode *&node, const string &key)
{
	auto parent = node->parent;
	if (node == nullptr)
	{
		splay(parent);
		return;
	}
	else if (node->value->key == key)
	{
		if (hasNotChildren(node))
		{
			delete node;
			node = nullptr;
			splay(parent);
		}
		else if (hasBothChildren(node))
		{
			auto minNode = findMinNode(node);
			const string temp1 = minNode->value->key;
			const string temp2 = minNode->value->value;
			removeNode(node, key);
			node->value->key = temp1;
			node->value->value = temp2;
			splay(parent);
		}
		else if (hasOnlyLeftChild(node))
		{
			auto toDelete = node;
			node = node->leftChild;
			delete toDelete;
			splay(parent);
		}
		else if (hasOnlyRightChild(node))
		{
			auto toDelete = node;
			node = node->rightChild;
			delete toDelete;
			splay(parent);
		}
		return;
	}
	else if (key > node->value->key)
	{
		return removeNode(node->rightChild, key);
	}
	else if (key < node->value->key)
	{
		return removeNode(node->leftChild, key);
	}
}

void removeNode(Tree *tree, const string &key)
{
	if (isEmpty(tree))
	{
		return;
	}

	return removeNode(tree->root, key);
}

void removeValue(TreeNode *&node)
{
	delete node->value;
	node->value = nullptr;
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
	removeValue(node);
	delete node;
	node = nullptr;
}

void removeTree(Tree *&tree)
{
	if (isEmpty(tree))
	{
		return;
	}

	removeTree(tree->root);
	delete tree;
	tree = nullptr;
}