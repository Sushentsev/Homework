#include <iostream>
using namespace std;

int main()
{
	int mass[11] = { 0 }, total = 0;
	cout << "Enter the array" << endl;
	for (int i = 0; i <= 10; i++)
	{
		cin >> mass[i];
	}

	for (int i = 0; i <= 10; i++)
	{
		if (mass[i] == 0)
		{
			total++;
		}
	}
	cout << "The number of zero elements is " << total << endl;
	system("pause");
	return 0;
}