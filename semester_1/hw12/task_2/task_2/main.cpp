#include "graph.h"
#include <iostream>
#include <fstream>

using namespace std;

void main()
{
	auto graph = createGraph(5);
	printGraph(graph, 5);
}