/* Knuth–Morris–Pratt algorithm */

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void loadFromFile(string &haystack, const string &fileName)
{
	ifstream file(fileName);
	if (file.is_open())
	{
		getline(file, haystack, '\0');
		file.close();
	}
	else
	{
		cout << "File is not found!" << endl;
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

int getFirstPosition(int *prefixArray, int arrayLength, int needleLength)
{
	int lastPosition = -1;
	for (int i = 0; i < arrayLength; ++i)
	{
		if (prefixArray[i] == needleLength)
		{
			lastPosition = i;
			return (lastPosition - 2 * needleLength);
		}
	}
	return lastPosition;
}

bool test1()
{
	bool flag = true;
	const int stringLength = 7;
	const string concatenatedString = "aabaaab";
	int *prefixArray = new int[stringLength] {};
	prefixFunction(concatenatedString, prefixArray);
	flag = (prefixArray[0] == 0) && (prefixArray[1] == 1) && (prefixArray[2] == 0) && (prefixArray[3] == 1) &&
		(prefixArray[4] == 2) && (prefixArray[5] == 2) && (prefixArray[6] == 3);
	delete[] prefixArray;
	return flag;
}

bool test2()
{
	bool flag = true;
	const int stringLength = 17;
	const string concatenatedString = "vet#onetwofiveten";
	int *prefixArray = new int[stringLength] {};
	prefixFunction(concatenatedString, prefixArray);
	flag = getFirstPosition(prefixArray, stringLength, 3) == 8;
	delete[] prefixArray;
	return flag;
}

bool test3()
{
	bool flag = 1;
	const int stringLength = 18;
	const string concatenatedString = "vett#onetwofiveten";
	int *prefixArray = new int[stringLength] {};
	prefixFunction(concatenatedString, prefixArray);
	flag = getFirstPosition(prefixArray, stringLength, 4) == -1;
	delete[] prefixArray;
	return flag;
}

void main()
{
	string haystack = "";
	string needle = "";
	string concatenatedString = "";
	string fileName = "";

	cout << "Test 1 (test prefix function): " << test1() << endl;
	cout << "Test 2 (test getting position): " << test2() << endl;
	cout << "Test 3 (test getting position): " << test3() << endl;

	cout << "Enter file name:" << endl;
	getline(cin, fileName);
	cout << "Enter needle:" << endl;
	getline(cin, needle);
	loadFromFile(haystack, fileName);

	concatenatedString = needle + "#" + haystack;
	int *prefixArray = new int[concatenatedString.length()]{};
	prefixFunction(concatenatedString, prefixArray);

	const int firstPosition = getFirstPosition(prefixArray, concatenatedString.length(), needle.length());
	if (firstPosition >= 0)
	{
		cout << "First position: " << firstPosition << endl;
	}
	else
	{
		cout << "Needle is not found!" << endl;
	}

	delete[] prefixArray;
}