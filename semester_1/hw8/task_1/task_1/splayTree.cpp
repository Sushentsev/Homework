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

void turnRight(TreeNode *&child)
{
	auto parentElement = child->parent;
	auto grandparentElement = parentElement->parent;

	if (grandparentElement != nullptr)
	{
		if (grandparentElement->leftChild = parentElement)
		{
			grandparentElement->leftChild = child;
		}
		else
		{
			grandparentElement->rightChild = child;
		}
	}

	if (parentElement->leftChild == child)
	{
		parentElement->leftChild = child->rightChild;
		if (parentElement->leftChild != nullptr)
		{
			parentElement->leftChild->parent = parentElement;
		}
		child->rightChild = parentElement;
	}
	else
	{
		parentElement->rightChild = child->leftChild;
		if (parentElement->rightChild != nullptr)
		{
			parentElement->rightChild->parent = parentElement;
		}
		child->leftChild = parentElement;
	}

	child->parent = grandparentElement;
	parentElement->parent = child;

	/*
	auto parent = child->parent;
	auto grandParent = parent->parent;

	if (grandParent != nullptr)
	{
		if (grandParent->leftChild = parent)
		{
			grandParent->leftChild = child;
		}
		else if (grandParent->rightChild = parent)
		{
			grandParent->rightChild = child;
		}
	}
	parent->leftChild = child->rightChild;
	if (parent->leftChild != nullptr)
	{
		parent->leftChild->parent = parent;
	}
	child->rightChild = parent;
	child->parent = grandParent;
	parent->parent = child;
	*/
}

void turnLeft(TreeNode *&child)
{

	auto parentElement = child->parent;
	auto grandparentElement = parentElement->parent;

	if (grandparentElement != nullptr)
	{
		if (grandparentElement->leftChild = parentElement)
		{
			grandparentElement->leftChild = child;
		}
		else
		{
			grandparentElement->rightChild = child;
		}
	}

	if (parentElement->leftChild == child)
	{
		parentElement->leftChild = child->rightChild;
		if (parentElement->leftChild != nullptr)
		{
			parentElement->leftChild->parent = parentElement;
		}
		child->rightChild = parentElement;
	}
	else
	{
		parentElement->rightChild = child->leftChild;
		if (parentElement->rightChild != nullptr)
		{
			parentElement->rightChild->parent = parentElement;
		}
		child->leftChild = parentElement;
	}

	child->parent = grandparentElement;
	parentElement->parent = child;

	/*
	auto parent = child->parent;
	auto grandParent = parent->parent;

	if (grandParent != nullptr)
	{
		if (grandParent->leftChild = parent)
		{
			grandParent->leftChild = child;
		}
		else if (grandParent->rightChild = parent)
		{
			grandParent->rightChild = child;
		}
	}
	parent->rightChild = child->leftChild;
	if (parent->rightChild != nullptr)
	{
		parent->rightChild->parent = parent;
	}
	child->leftChild = parent;
	child->parent = grandParent;
	parent->parent = child;
	*/
}

void zig(TreeNode *&child, TreeNode *&parent)
{
	if (parent->leftChild == child)
	{
		turnRight(child);
	}
	else if (parent->rightChild == child)
	{
		turnLeft(child);
	}
}

void zigZag(TreeNode *&child, TreeNode *&parent)
{
	if (parent->leftChild == child)
	{
		turnRight(child);
		turnLeft(child);
	}
	else if (parent->rightChild == child)
	{
		turnLeft(child);
		turnRight(child);
	}
}

void zigZig(TreeNode *&child, TreeNode *&parent)
{
	if (parent->leftChild == child)
	{
		turnRight(parent);
		turnRight(child);
	}
	else if (parent->rightChild == child)
	{
		turnLeft(parent);
		turnLeft(child);
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

bool isLeaf(TreeNode *node)
{
	return (node->leftChild == nullptr && node->rightChild == nullptr);
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
	else if (isLeaf(node))
	{
		splay(node);
		return "";
	}
	else if (key < node->value->key)
	{
		return getValue(node->leftChild, key);
	}
	else
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
	else if (isLeaf(node))
	{
		splay(node);
		return false;
	}
	else if (key < node->value->key)
	{
		return isContained(node->leftChild, key);
	}
	else
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

void addNode(TreeNode *&node, TreeNode *&parent, const string &key, const string &value)
{
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
		return addNode(node->leftChild, node, key, value);
	}
	else if (key > node->value->key)
	{
		return addNode(node->rightChild, node, key, value);
	}
}

void addNode(Tree *tree, const string &key, const string &value)
{
	if (isEmpty(tree))
	{
		tree->root = createTreeNode(key, value, nullptr, nullptr, nullptr);
		return;
	}
	auto parent = new TreeNode{ nullptr };
	addNode(tree->root, parent, key, value);
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

void removeNode(TreeNode *&node, TreeNode *&parent, const string &key)
{
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
			removeNode(node,parent, key);
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
		return removeNode(node->rightChild, node, key);
	}
	else if (key < node->value->key)
	{
		return removeNode(node->leftChild, node, key);
	}
}

void removeNode(Tree *tree, const string &key)
{
	if (isEmpty(tree))
	{
		return;
	}
	auto parent = new TreeNode{ nullptr };
	return removeNode(tree->root, parent, key);
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