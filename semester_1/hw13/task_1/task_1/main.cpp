#include "lexicalAnalyzer.h"
#include <iostream>
#include <string>

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
	string str = "";

	cout << "Test: " << test() << endl;
	cout << "Enter a string:" << endl;
	getline(cin, str);
	if (isRealNumber(str))
	{
		cout << "It is a real number" << endl;
	}
	else
	{
		cout << "It is not a real number" << endl;
	}
}