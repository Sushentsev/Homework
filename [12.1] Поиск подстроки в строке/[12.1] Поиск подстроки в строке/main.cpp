/* KnuthЦMorrisЦPratt algorithm */

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

int getFirstPosition(int *prefixArray, int arrayLength, int needleLength)
{
	int lastPosition = -1;
	for (int i = 0; i < arrayLength; ++i)
	{
		if (prefixArray[i] == needleLength)
		{
			lastPosition = i;
			return (lastPosition - needleLength - 2);
		}
	}
	return lastPosition;
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

bool test2()
{
	bool flag = 1;
	const int stringLength = 17;
	string concatenatedString = "vet#onetwofiveten";
	int *prefixArray = new int[stringLength] {};
	prefixFunction(concatenatedString, prefixArray);
	flag = getFirstPosition(prefixArray, stringLength, 3) == 9;
	delete[] prefixArray;
	prefixArray = nullptr;
	return flag;
}

bool test3()
{
	bool flag = 1;
	const int stringLength = 18;
	string concatenatedString = "vett#onetwofiveten";
	int *prefixArray = new int[stringLength] {};
	prefixFunction(concatenatedString, prefixArray);
	flag = getFirstPosition(prefixArray, stringLength, 4) == -1;
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

	int firstPosition = getFirstPosition(prefixArray, concatenatedString.length(), needle.length());
	if (firstPosition >= 0)
	{
		cout << "ѕозици€ первого вхождени€ (нумераци€ с единицы): " << firstPosition << endl;
	}
	else
	{
		cout << "ќбразец не найден!" << endl;
	}

	delete[] prefixArray;
	prefixArray = nullptr;
}