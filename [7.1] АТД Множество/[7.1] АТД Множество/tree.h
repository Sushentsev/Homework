#pragma once

/* Описание структуры узла */
struct TreeNode;

/* Описание структуры дерева */
struct Tree;

/* Создание дерева */
Tree *plantTree();

/* Добавление узла */
bool addNode(Tree *tree, int value);

/* Удаление узла */
bool removeNode(Tree *tree, int value);

/* Проверка на содержания значения в дереве*/
bool isContained(Tree *tree, int value);

/* Печать в возрастающем порядке */
void printAscendingOrder(Tree *tree);

/* Печать в убывающем порядке */
void printDescendingOrder(Tree *tree);

/* Удаление дерева */
void removeTree(Tree *tree);