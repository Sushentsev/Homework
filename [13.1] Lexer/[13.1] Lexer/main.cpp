#include <iostream>
#include <string>
#include "lexicalAnalyzer.h"

using namespace std;

bool test()
{
	string s1 = "1.2345";
	string s2 = "12454.";
	string s3 = "1n.43";
	string s4 = "123.E78";
	string s5 = "123.45E++45";
	string s6 = "13.5E-142";
	string s7 = "ggtr";
	string s8 = "12.456E45";
	return (isRealNumber(s1) && !isRealNumber(s2) && !isRealNumber(s3) && !isRealNumber(s4) && !isRealNumber(s5) && isRealNumber(s6) && !isRealNumber(s7) 
		&& isRealNumber(s8));
}

void main()
{
	setlocale(LC_ALL, "Russian");
	string str = "";

	cout << "Test: " << test() << endl;
	cout << "¬ведите искомую строку:" << endl;
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