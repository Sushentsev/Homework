#include "graph.h"
#include <iostream>
#include <string>

using namespace std;

struct Graph
{
	int **weight;
	int size;
};

int sizeOfGraph(Graph *graph)
{
	return graph->size;
}

int getValue(Graph *graph, int i, int j)
{
	return graph->weight[i][j];
}

Graph *createGraph(int size)
{
	auto graph = new Graph{ new int *[size], size };
	for (int i = 0; i < size; ++i)
	{
		graph->weight[i] = new int[size] {};
	}
	return graph;
}

void inputGraph(Graph *graph, int i, int j, int value)
{
	graph->weight[i][j] = value;
	graph->weight[j][i] = value;
}

void printGraph(Graph *graph)
{
	const int size = graph->size;
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			cout << graph->weight[i][j] << " ";
		}
		cout << endl;
	}
}

void removeGraph(Graph *&graph)
{
	const int size = graph->size;
	for (int i = 0; i < size; ++i)
	{
		delete graph->weight[i];
	}
	delete graph->weight;
	delete graph;
	graph = nullptr;
}