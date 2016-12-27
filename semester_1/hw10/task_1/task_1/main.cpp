#include "graph.h"
#include "list.h"
#include "cities.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

bool test()
{
	bool flag = true;
	string fileName = "test.txt";
	int n = 0;
	int m = 0;
	int k = 0;
	ifstream file(fileName);
	file >> n;
	file >> m;
	auto graph = createGraph(n);
	readGraphFromFile(graph, file, m);
	file >> k;
	auto country = createCountries(k);
	readCapitalsFromFile(country, file, k);
	file.close();
	getCountries(graph, country, k);
	flag = isContained(country, 2, 5, k) && isContained(country, 2, 7, k) && !isContained(country, 2, 3, k)
		&& isContained(country, 4, 3, k) && isContained(country, 6, 0, k) && !isContained(country, 6, 9, k);
	removeGraph(graph);
	removeCountries(country, k);
	return flag;
}

void main()
{
	string fileName = "";
	int n = 0;
	int m = 0;
	int k = 0;
	cout << "Test: " << test() << endl << endl;
	cout << "Enter file name:" << endl;
	cin >> fileName;

	ifstream file(fileName);
	file >> n;
	file >> m;
	auto graph = createGraph(n);
	readGraphFromFile(graph, file, m);
	file >> k;
	auto country = createCountries(k);
	readCapitalsFromFile(country, file, k);
	file.close();

	cout << "Graph of roads: " << endl;
	printGraph(graph);
	cout << endl << endl;
	getCountries(graph, country, k);
	cout << "Capitals and cities: " << endl;
	printCountries(country, k);
	removeGraph(graph);
	removeCountries(country, k);
}