#include <iostream>
#include <string>
#include "splayTree.h"

using namespace std;

//void printInformation();

bool test()
{
	auto tree = plantTree();

	string key1 = "1";
	string key2 = "2";
	string value1 = "value1";
	string value2 = "value2";

	addNode(tree, key1, value1);
	addNode(tree, key2, value2);
	removeNode(tree, key1);
	const bool ok = ((isContained(tree, key1) == false) && (getValue(tree, key2) == "value2"));

	removeTree(tree);

	return ok;
}

void main()
{
	cout << test();
}