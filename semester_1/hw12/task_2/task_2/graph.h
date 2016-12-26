#pragma once
#include <string>

/* The structure of graph */
struct Graph;

/* Creating graph, all elements are 0 */
Graph *createGraph(int size);

/* Creatong graph, all elements are from file */
Graph *createGraphFromFile(const std::string &fileName);

/* Finding tree */
Graph *findTree(Graph *graph);

/* Getting sum of all elements */
int getSum(Graph *graph);

/* Removing graph */
void removeGraph(Graph *&graph);

/* Printing graph */
void printGraph(Graph *graph);