#pragma once

struct TreeElement;
struct Tree;
Tree* plantTree();
void addElement(Tree *tree, int value);
void deleteElement(Tree *tree, int value);
bool isContained(Tree *tree, int value);
void printAscendingOrder(Tree *tree);
void printDescendingOrder(Tree *tree);