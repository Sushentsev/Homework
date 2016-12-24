#include <iostream>
#include <string>
#include <fstream>
#include "dfa.h"

using namespace std;

void loadStatesFromFIle(int stateTable[3][4])
{
	int state = 0;

	ifstream file("states.txt");
	if (file.is_open())
	{
		for (int i = 0; i <= 2; ++i)
		{
			for (int j = 0; j <= 3; ++j)
			{
				file >> state;
				stateTable[i][j] = state;
			}
		}
		file.close();
	}
	else
	{
		cout << "File with states is not found!" << endl;
	}
}

int getState(const int stateTable[3][4], const int state, const char &symbol)
{
	switch (symbol)
	{
	case '/':
	{
		return stateTable[0][state];
		break;
	}
	case '*':
	{
		return stateTable[1][state];
		break;
	}
	default:
	{
		return stateTable[2][state];
		break;
	}
	}
}

void readComments(const int stateTable[3][4], const string &fileName, string &comments)
{
	int state = 0;
	ifstream file(fileName);

	if (file.is_open())
	{
		while (!file.eof())
		{
			char symbol = file.get();
			state = getState(stateTable, state, symbol);

			switch (state)
			{
			case 0:
			{
				break;
			}
			case 1:
			{
				comments = symbol;
				break;
			}
			case 2:
			{
				comments += symbol;
				break;
			}
			case 3:
			{
				comments += symbol;
				break;
			}
			case 4:
			{
				comments += symbol;
				state = 0;
				cout << comments << endl;
				break;
			}
			}
		}
		file.close();
	}
	else
	{
		cout << "File with comments is not found!" << endl;
	}
}