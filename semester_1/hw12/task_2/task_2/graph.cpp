#include "graph.h"
#include <iostream>
#include <fstream>

using namespace std;	

struct Graph
{
	int **weight;
	int sizeOfGraph;
};

Graph *createGraph(int size)
{
	auto graph = new Graph { new int *[size], size };

	for (int i = 0; i < size; ++i)
	{
		graph->weight[i] = new int[size] {};
	}

	return graph;
}

void removeGraph(Graph *&graph)
{
	const int size = graph->sizeOfGraph;
	for (int i = 0; i < size; ++i)
	{
		delete[] graph->weight[i];
		graph->weight[i] = nullptr;
	}

	delete[] graph->weight;
	graph->weight = nullptr;
	delete graph;
	graph = nullptr;
}

void printGraph(Graph *graph)
{
	const int size = graph->sizeOfGraph;
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			cout << graph->weight[i][j] << " ";
		}
		cout << endl;
	}
}