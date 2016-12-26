#include "graph.h"
#include <iostream>
#include <string>
#include <fstream>

using namespace std;

bool test()
{
	bool flag = true;
	auto graph = createGraphFromFile("test.txt");
	auto tree = findTree(graph);
	flag = getSum(tree) / 2 == 39;
	removeGraph(tree);
	removeGraph(graph);
	return flag;
}

void main()
{
	string fileName = "";
	cout << "Test: " << test() << endl << endl;

	cout << "Enter file name: " << endl;
	cin >> fileName;
	auto graph = createGraphFromFile(fileName);
	cout << "Graph from file:" << endl;
	printGraph(graph);
	cout << endl;
	auto tree = findTree(graph);
	cout << "Tree:" << endl;
	printGraph(tree);
	removeGraph(tree);
	removeGraph(graph);
}