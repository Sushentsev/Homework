#include <iostream>
using namespace std;

int main()
{
	int x = 0, i, k, numberDivisors = 0;
	cout << "Enter x" << endl;
	cin >> x;
	cout << "All prime numbers in [2; " << x << "]: ";
	for (i = 2; i <= x; i++)
	{
		for (k = 2; k <= i; k++)
		{
			if (i % k == 0)
			{
				numberDivisors++;
			}
		}

		if (numberDivisors == 1)
		{
			cout << i << " ";
		}
		numberDivisors = 0;
	}
	system("pause");
	return 0;

}