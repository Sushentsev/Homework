#include <iostream>
using namespace std;

int main()
{
	int frequencyOfSum[28] = { 0 }, happyTickets = 0;
	for (int i = 0; i <= 9; i++)
	{
		for (int j = 0; j <= 9; j++)
		{
			for (int k = 0; k <= 9; k++)
			{
				frequencyOfSum[i + j + k]++;
			}
		}
	}
	for (int i = 0; i <= 27; i++)
	{
		happyTickets += frequencyOfSum[i] * frequencyOfSum[i];
	}
	cout << "The total number of happy tickets is " << happyTickets << endl;
	system("pause");
	return 0;

}