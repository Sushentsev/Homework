#include <iostream>
#include <string>
#include "dfa.h"

using namespace std;

bool test()
{
	int stateTable[3][4]{};
	string fileName = "test.txt";
	string comments = "";
	loadStatesFromFIle(stateTable);
	readComments(stateTable, fileName, comments);
	return comments == "/* test /// * em */";
}

void main()
{
	setlocale(LC_ALL, "Russian");
	string fileName = "";
	string comments = "";
	int stateTable[3][4]{};
	cout << "Test: " << test() << endl << endl;
	cout << "Enter file name:" << endl;
	getline(cin, fileName);
	loadStatesFromFIle(stateTable);
	readComments(stateTable, fileName, comments);
}