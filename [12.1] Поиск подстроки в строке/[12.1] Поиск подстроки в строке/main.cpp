#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void loadFromFile(string &haystack)
{
	ifstream file("input.txt");
	if (file.is_open())
	{
		getline(file, haystack, '\0');
		file.close();
	}
	else
	{
		cout << "ќшибка при открытии файла" << endl;
	}
}

void prefixFunction(const string &concatenatedString, int *prefixArray)
{
	const int stringLength = concatenatedString.length();
	prefixArray[0] = 0;
	for (int i = 1; i < stringLength; ++i)
	{
		int position = prefixArray[i - 1];
		while ((position > 0) && (concatenatedString[i] != concatenatedString[position]))
		{
			position = prefixArray[position - 1];
		}
		if (concatenatedString[i] == concatenatedString[position])
		{
			++position;
		}
		prefixArray[i] = position;
	}
}

bool test1()
{
	bool flag = 1;
	const int stringLength = 7;
	string concatenatedString = "aabaaab";
	int *prefixArray = new int[stringLength]{};
	prefixFunction(concatenatedString, prefixArray);
	flag = (prefixArray[0] == 0) && (prefixArray[1] == 1) && (prefixArray[2] == 0) && (prefixArray[3] == 1) &&
		(prefixArray[4] == 2) && (prefixArray[5] == 2) && (prefixArray[6] == 3);
	delete[] prefixArray;
	prefixArray = nullptr;
	return flag;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	string haystack = "";
	string needle = "";
	string concatenatedString = "";
	cout << "Test 1 (test prefix function): " << test1() << endl;
	cout << "Test 2 (test getting position): " << test2() << endl;
	cout << "Test 3 (test getting position): " << test3() << endl;

 	cout << "¬ведите образец:" << endl;
	getline(cin, needle);
	loadFromFile(haystack);

	concatenatedString = needle + "#" + haystack;
	int *prefixArray = new int[concatenatedString.length()]{};
	prefixFunction(concatenatedString, prefixArray);

	delete[] prefixArray;
	prefixArray = nullptr;
}