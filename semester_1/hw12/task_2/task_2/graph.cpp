#include "graph.h"
#include <iostream>
#include <string>
#include <fstream>

using namespace std;	

struct Graph
{
	int **weight;
	int sizeOfGraph;
};

Graph *createGraph(int size)
{
	auto graph = new Graph{ new int *[size], size };
	for (int i = 0; i < size; ++i)
	{
		graph->weight[i] = new int[size] {};
	}
	return graph;
}

Graph *createGraphFromFile(const string &fileName)
{
	int temp = 0;
	int size = 0;
	ifstream file(fileName);
	file >> size;
	auto graph = new Graph { new int *[size], size };

	for (int i = 0; i < size; ++i)
	{
		graph->weight[i] = new int[size] {};
		for (int j = 0; j < size; ++j)
		{
			file >> temp;
			graph->weight[i][j] = temp;
		}
	}
	file.close();

	return graph;
}

int getSum(Graph *graph)
{
	const int size = graph->sizeOfGraph;
	int sum = 0;
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			sum += graph->weight[i][j];
		}
	}
	return sum;
}

void setDistance(Graph *tree, int i, int j, int distance)
{
	tree->weight[i][j] = distance;
	tree->weight[j][i] = distance;
}

void markVertex(bool *visitedVertices, int i)
{
	visitedVertices[i] = true;
}

Graph *findTree(Graph *graph)
{
	const int size = graph->sizeOfGraph;
	auto tree = createGraph(size);
	auto visitedVertices = new bool[size] { false };
	int numberOfVisitedVertices = 1;
	visitedVertices[0] = true;

	while (numberOfVisitedVertices < size)
	{
		int minDistance = INT_MAX;
		int indexI = 0;
		int indexJ = 0;

		for (int i = 0; i < size; ++i)
		{
			if (visitedVertices[i])
			{ 
				for (int j = 0; j < size; ++j)
				{
					int distance = graph->weight[i][j];
					if (!visitedVertices[j] && (minDistance > distance) && (distance > 0))
					{
						minDistance = distance;
						indexI = i;
						indexJ = j;
					}
				}	
			}
		}
		markVertex(visitedVertices, indexJ);
		setDistance(tree, indexI, indexJ, minDistance);
		++numberOfVisitedVertices;
	}

	delete[] visitedVertices;
	return tree;
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