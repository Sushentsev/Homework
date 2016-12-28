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
	return new Tree{ nullptr };
}

TreeNode* createTreeNode(const string &key, const string &value, TreeNode *leftChild, TreeNode *rightChild, TreeNode *parent)
{
	return new TreeNode{ new Element{ key, value }, leftChild, rightChild, parent };
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

bool isLeftChild(TreeNode *child, TreeNode *parent)
{
	if (parent == nullptr)
	{
		return false;
	}
	return (child == parent->leftChild);
}

bool isRightChild(TreeNode *child, TreeNode *parent)
{
	if (parent == nullptr)
	{
		return false;
	}
	return (child == parent->rightChild);
}

bool hasLeftChild(TreeNode *node)
{
	if (node == nullptr)
	{
		return false;
	}
	return (node->leftChild != nullptr);
}

bool hasRightChild(TreeNode *node)
{
	if (node == nullptr)
	{
		return false;
	}
	return (node->rightChild != nullptr);
}

void turnRight(TreeNode *child, TreeNode *parent)
{
	if (parent->parent != nullptr)
	{
		if (isLeftChild(parent, parent->parent))
		{
			parent->parent->leftChild = child;
		}
		else if (isRightChild(parent, parent->parent))
		{
			parent->parent->rightChild = child;
		}
	}
	child->parent = parent->parent;
	if (hasRightChild(child))
	{
		parent->leftChild = child->rightChild;
		parent->leftChild->parent = parent;
	}
	else
	{
		parent->leftChild = nullptr;
	}

	child->rightChild = parent;
	parent->parent = child;
}

void turnLeft(TreeNode *child, TreeNode *parent)
{
	if (parent->parent != nullptr)
	{
		if (isLeftChild(parent, parent->parent))
		{
			parent->parent->leftChild = child;
		}
		else if (isRightChild(parent, parent->parent))
		{
			parent->parent->rightChild = child;
		}
	}
	child->parent = parent->parent;
	if (hasLeftChild(child))
	{
		parent->rightChild = child->leftChild;
		parent->rightChild->parent = parent;
	}
	else
	{
		parent->rightChild = nullptr;
	}

	child->leftChild = parent;
	parent->parent = child;
}

void zig(TreeNode *child, TreeNode *parent)
{
	if (isLeftChild(child, parent))
	{
		turnRight(child, parent);
	}
	else if (isRightChild(child, parent))
	{
		turnLeft(child, parent);
	}
}

void zigZig(TreeNode *child, TreeNode *parent)
{
	if (isLeftChild(parent, parent->parent))
	{
		turnRight(parent, parent->parent);
		turnRight(child, parent);
	}
	else if (isRightChild(parent, parent->parent))
	{
		turnLeft(parent, parent->parent);
		turnLeft(child, parent);
	}
}

void zigZag(TreeNode *child, TreeNode *parent)
{
	if (isLeftChild(child, parent))
	{
		turnRight(child, parent);
		turnLeft(child, child->parent);
	}
	else if (isRightChild(child, parent))
	{
		turnLeft(child, parent);
		turnRight(child, child->parent);
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

void splay(Tree *tree, TreeNode *node)
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
	tree->root = node;
}

string getValue(Tree *tree, TreeNode *node, TreeNode *parent, const string &key)
{
	if (node == nullptr)
	{
		splay(tree, parent);
		return "";
	}
	else if (node->value->key == key)
	{
		splay(tree, node);
		return node->value->value;
	}
	else if (key < node->value->key)
	{
		return getValue(tree, node->leftChild, node, key);
	}
	else
	{
		return getValue(tree, node->rightChild, node, key);
	}
}

string getValue(Tree *tree, const string &key)
{
	if (isEmpty(tree))
	{
		return "";
	}
	return getValue(tree, tree->root, nullptr, key);
}

bool isContained(Tree *tree, TreeNode *node, TreeNode *parent, const string &key)
{
	if (node == nullptr)
	{
		splay(tree, parent);
		return false;
	}
	else if (node->value->key == key )
	{
		splay(tree, node);
		return true;
	}
	else if (key < node->value->key)
	{
		return isContained(tree, node->leftChild, node, key);
	}
	else
	{
		return isContained(tree, node->rightChild, node, key);
	}
}

bool isContained(Tree *tree, const string &key)
{
	if (isEmpty(tree))
	{
		return false;
	}
	return isContained(tree, tree->root, nullptr, key);
}

void addNode(Tree *tree, TreeNode *&node, TreeNode *&parent, const string &key, const string &value)
{
	if (node == nullptr)
	{
		node = createTreeNode(key, value, nullptr, nullptr, parent);
		splay(tree, node);
		return;
	}
	else if (node->value->key == key)
	{
		node->value->value = value;
		splay(tree, node);
		return;
	}
	else if (key < node->value->key)
	{
		return addNode(tree, node->leftChild, node, key, value);
	}
	else if (key > node->value->key)
	{
		return addNode(tree, node->rightChild, node, key, value);
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
	addNode(tree, tree->root, parent, key, value);
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

void removeNode(Tree *tree, TreeNode *&node, TreeNode *parent, const string &key)
{
	if (node == nullptr)
	{
		splay(tree, parent);
		return;
	}
	else if (node->value->key == key)
	{
		if (hasNotChildren(node))
		{
			delete node;
			node = nullptr;
			splay(tree, parent);
		}
		else if (hasBothChildren(node))
		{
			auto minNode = findMinNode(node);
			const string temp1 = minNode->value->key;
			const string temp2 = minNode->value->value;
			removeNode(tree, node, parent, key);
			node->value->key = temp1;
			node->value->value = temp2;
			splay(tree, parent);
		}
		else if (hasOnlyLeftChild(node))
		{
			auto toDelete = node;
			node = node->leftChild;
			node->parent = parent;
			delete toDelete;
			splay(tree, parent);
		}
		else if (hasOnlyRightChild(node))
		{
			auto toDelete = node;
			node = node->rightChild;
			node->parent = parent;
			delete toDelete;
			splay(tree, parent);
		}
		return;
	}
	else if (key > node->value->key)
	{
		return removeNode(tree, node->rightChild, node, key);
	}
	else if (key < node->value->key)
	{
		return removeNode(tree, node->leftChild, node, key);
	}
}

void removeNode(Tree *tree, const string &key)
{
	if (isEmpty(tree))
	{
		return;
	}
	auto parent = new TreeNode{ nullptr };
	return removeNode(tree, tree->root, parent, key);
}

void removeValue(TreeNode *node)
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