#include <iostream>
#include <string>

using namespace std;

int main()
{
	int count = 0;
	int i = 0;
	string s = "";
	cout << "Enter the string" << endl;
	getline(cin, s);

	while (count >= 0 && i <= s.length() - 1)
	{
		if (s[i] == '(')
		{
			++count;
		}

		if (s[i] == ')')
		{
			--count;
		}
		++i;
	}

	if (count == 0)
	{
		cout << "All is well" << endl;
	}
	else
	{
		cout << "Something wrong" << endl;
	}

	return 0;
}