#pragma once

struct TreeNode;
struct Tree;

bool addNode(Tree *tree, int value);
bool removeNode(Tree *tree, int value);
bool isContained(Tree *tree, int value);
void printAscendingOrder(Tree *tree);
void printDescendingOrder(Tree *tree);