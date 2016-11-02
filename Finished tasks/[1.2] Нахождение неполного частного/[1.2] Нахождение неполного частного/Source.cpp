#include <iostream>

using namespace std;

int partialQuotient(int a, int b)
{
	int result = 1;
	while (abs(a) >= abs(b) * result)
	{
		++result;
	}
	if (a >= 0)
	{
		--result;
	}
	if (a * b < 0)
	{
		result *= -1;
	}
	return result;
}

bool test1()
{
	int a = 13;
	int b = 5;
	return partialQuotient(a, b) == 2;
}

bool test2()
{
	int a = 2;
	int b = 2;
	return partialQuotient(a, b) == 1;
}

bool test3()
{
	int a = 5;
	int b = 6;
	return partialQuotient(a, b) == 0;
}

bool test4()
{
	int a = -13;
	int b = -5;
	return partialQuotient(a, b) == 3;
}

bool test5()
{
	int a = -12;
	int b = 7;
	return partialQuotient(a, b) == -2;
}

bool test6()
{
	int a = 17;
	int b = -5;
	return partialQuotient(a, b) == -3;
}

void main()
{
	int a = 0;
	int b = 0;
	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;
	cout << "Test 3: " << test3() << endl;
	cout << "Test 4: " << test4() << endl;
	cout << "Test 5: " << test5() << endl;
	cout << "Test 6: " << test6() << endl;
	cout << "Enter any numbers A and B (not 0)" << endl;
	cin >> a >> b;
	cout << "The result is " << partialQuotient(a, b) << endl;
}