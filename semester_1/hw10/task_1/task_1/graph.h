#pragma once

/* The strcture of graph */
struct Graph;

/* Creating graph */
Graph *createGraph(int size);

/* Getting the size of graph */
int sizeOfGraph(Graph *graph);

/* Getting value from graph */
int getValue(Graph *graph, int i, int j);

/* Enter the value in graph */
void inputGraph(Graph *graph, int i, int j, int value);

/* Printing graph */
void printGraph(Graph *graph);

/* Removing graph */
void removeGraph(Graph *&graph);
