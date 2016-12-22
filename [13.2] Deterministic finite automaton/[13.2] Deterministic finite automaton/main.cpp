#include <iostream>
#include <string>
#include "dfa.h"

using namespace std;

void main()
{
	setlocale(LC_ALL, "Russian");
	string fileName = "";
	string comments = "";
	int stateTable[3][4]{};

	cout << "¬ведите название файла:" << endl;
	cin >> fileName;
	loadStatesFromFIle(stateTable);
	readComments(stateTable, fileName, comments);

	cout << comments << endl;
}