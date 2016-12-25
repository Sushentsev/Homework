#pragma once
#include <string>

/* The structure of tree node */
struct TreeNode;

/* The structure of tree */
struct Tree;

/* Planting tree */
Tree* plantTree();

/* Building tree */
void buildTree(Tree *&tree, const std::string &expression);

/* Printing tree */
void printTree(Tree *tree);

/* Computing tree */
double computeTree(Tree *tree);

/* Removing tree */
void removeTree(Tree *&tree);