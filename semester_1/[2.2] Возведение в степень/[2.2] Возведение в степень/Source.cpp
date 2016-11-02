#include <iostream>
#include <cmath>
using namespace std;

int logarithmicTime(int base, int power)
{
	if (power == 1)
	{
		return base;
	}
	if (power % 2 == 0)
	{
		return pow(logarithmicTime(base, power / 2), 2);
	}
	else
	{
		return pow(logarithmicTime(base, (power - 1) / 2), 2) * base;
	}
}

int linearTime(int base, int power)
{
	int result = 1;
	for (int i = 1; i <= power; ++i)
	{
		result *= base;
	}
	return result;
}

void main()
{
	int base = 0;
	int power = 0;
	cout << "Enter the base (>=0) and the exponent (>=1) " << endl;
	cin >> base >> power;
	cout << "Result [logarithmic time]: " << logarithmicTime(base, power) << endl;
	cout << "Result [linear time]: " << linearTime(base, power) << endl;
}