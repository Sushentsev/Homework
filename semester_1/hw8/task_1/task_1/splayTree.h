#pragma once
#include <string>

using namespace std;

/* The structure of node of tree */
struct TreeNode;

/* The structure of tree */
struct Tree;

/* Planting tree */
Tree* plantTree();

/* Getting value by key */
string getValue(Tree *tree, const string &key);

/* Checking whether key is contained */
bool isContained(Tree *tree, const string &key);

/* Adding new node or changing it if key is contained */
void addNode(Tree *tree, const string &key, const string &value);

/* Removing node if key is contained */
void removeNode(Tree *tree, const string &key);

/* Removing tree */
void removeTree(Tree *&tree);
