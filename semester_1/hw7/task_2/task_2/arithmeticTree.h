#pragma once
#include <string>

using namespace std;

struct TreeNode;

struct Tree;

Tree* plantTree();

void buildTree(Tree *&tree, const string &expression);

void printTree(Tree *tree);

void removeTree(Tree *&tree);