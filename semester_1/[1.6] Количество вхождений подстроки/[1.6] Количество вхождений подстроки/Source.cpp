#include <iostream>
#include <string>
using namespace std;

int main()
{
	string s = "";
	string s1 = "";
	int result = 0;
	cout << "Enter S" << endl;
	getline(cin, s);
	cout << "Enter S1" << endl;
	getline(cin, s1);
	for (int i = 0; i <= s.length() - s1.length(); ++i)
	{
		if (s[i] == s1[0])
		{
			int k1 = i;
			int k2 = 0;
			int count = 0;
			while ((s[k1] == s1[k2]) && (count != s1.length()))
			{
				if (s[k1] == s1[k2])
				{
					++count;
				}
				++k1;
				++k2;
			}

			if (count == s1.length())
			{
				++result;
			}
		}
	}

	cout << "Number substring is " << result << endl;
	return 0;
}