#include "arithmeticTree.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void loadExpression(string &expression, const string &fileName)
{
	ifstream file(fileName);
	if (file.is_open())
	{
		getline(file, expression, '\0');
		file.close();
	}
	else
	{
		cout << "File is not found!" << endl;
	}
}

bool test()
{
	auto tree = plantTree();
	bool flag = true;
	string expression = "";
	const string fileName = "test.txt";

	loadExpression(expression, fileName);
	buildTree(tree, expression);
	flag = computeTree(tree) == 25;
	removeTree(tree);
	return flag;
}

void main()
{
	auto tree = plantTree();
	string expression = "";
	string fileName = "";

	cout << "Test: " << test() << endl;
	cout << "Enter file name:" << endl;
	cin >> fileName;
	loadExpression(expression, fileName);
	buildTree(tree, expression);
	printTree(tree);
	cout << endl;
	cout << computeTree(tree) << endl;
	removeTree(tree);
}