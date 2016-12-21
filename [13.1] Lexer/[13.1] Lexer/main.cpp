#include <iostream>
#include <string>
#include "lexicalAnalyzer.h"

using namespace std;

bool isNumber(const char &symbol)
{
	return (symbol >= '0' && symbol <= '9');
}

bool isRealNumber(const string &str)
{
	bool state = 0;
	char symbol = '0';
	for (int i = 0; i < str.length(); ++i)
	{
		symbol = str[i];
		switch (state)
		{
			case 0:
			{

			}
			case 1:
			{

			}
			case 2:
			{

			}
			case 3:
			{

			}
			case 4:
			{

			}
			case 5:
			{

			}
		}
	}

	return state;
}

bool test()
{
	return 1;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	string str = "";

	cout << "Test: " << test() << endl;

	cout << "¬ведите иискомую строку:" << endl;
	getline(cin, str);

	if (isRealNumber(str))
	{
		cout << "ѕоследовательность €вл€етс€ вещественным числом" << endl;
	}
	else
	{
		cout << "ѕоследовательность не €вл€етс€ вещественным числом" << endl;
	}
}