#include <iostream>
#include <string>
#include "splayTree.h"

using namespace std;

void printInformation()
{
	cout << endl;
	cout << "Choose operation:" << endl;
	cout << "0 - Exit;" << endl;
	cout << "1 - Add new value;" << endl;
	cout << "2 - Get value by key;" << endl;
	cout << "3 - Is key contained;" << endl;
	cout << "4 - Remove key with value;" << endl << endl;
}

void addKey(Tree *tree)
{
	string key = "";
	string value = "";
	cout << "Enter key:" << endl;
	cin >> key;
	cout << "Enter value:" << endl;
	cin >> value;
	addNode(tree, key, value);
	cout << "Done!" << endl;
}

void getValue(Tree *tree)
{
	string key = "";
	cout << "Enter key:" << endl;
	cin >> key;
	cout << "The value is " << getValue(tree, key) << endl;
}

void isContained(Tree *tree)
{
	string key = "";
	cout << "Enter key:" << endl;
	cin >> key;
	cout << "Is contained: " << isContained(tree, key) << endl;
}

void removeKey(Tree *tree)
{
	string key = "";
	cout << "Enter key:" << endl;
	cin >> key;
	removeNode(tree, key);
	cout << "Done!" << endl;
}

bool test()
{
	auto tree = plantTree();
	bool flag = true;
	string key1 = "1";
	string key2 = "2";
	string key3 = "-1";
	string key4 = "5";
	string value1 = "value1";
	string value2 = "value2";
	string value3 = "value3";
	string value4 = "value5";

	addNode(tree, key1, value1);
	addNode(tree, key2, value2);
	addNode(tree, key3, value3);
	addNode(tree, key4, value4);
	removeNode(tree, key1);
	removeNode(tree, key3);
	addNode(tree, key3, value3);
	flag = (isContained(tree, key1) == false) && (getValue(tree, key2) == "value2") && 
		(isContained(tree, key2) == true);
	removeTree(tree);
	return flag;
}

void main()
{
	cout << "Test: " << test() << endl;
	auto tree = plantTree();
	int selection = -1;

	while (selection != 0)
	{
		printInformation();
		cin >> selection;
		switch (selection)
		{
		case 1:
		{
			addKey(tree);
			break;
		}
		case 2:
		{
			getValue(tree);
			break;
		}
		case 3:
		{
			isContained(tree);
			break;
		}
		case 4:
		{
			removeKey(tree);
			break;
		}
		default:
			break;
		}
	}
	removeTree(tree);
}