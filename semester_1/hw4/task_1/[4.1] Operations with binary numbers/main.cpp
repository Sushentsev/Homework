#include <iostream>

using namespace std;

const int length = sizeof(int) * 8;

void printNumber(bool number[])
{
	for (int i = 0; i < length; ++i)
	{
		cout << number[i];
	}
}

void reverse(bool number[])
{
	for (int i = 0; i < length / 2; ++i)
	{
		swap(number[i], number[length - i - 1]);
	}
}

void intoBinaryNumber(bool number[], int x)
{
	int bit = 1;
	for (int i = 0; i < length; ++i)
	{
		number[i] = x & bit;
		bit = bit << 1;
	}
	reverse(number);
}

void binarySum(bool num1[], bool num2[], bool sum[])
{
	int rest = 0;
	for (int i = sizeof(int) * 8 - 1; i >= 0 ; --i)
	{
		int currentSum = num1[i] + num2[i] + rest;
		sum[i] = currentSum % 2;
		rest = currentSum / 2;
	}
}

int intoDecimalPositiveNumber(bool sum[])
{
	reverse(sum);
	int decimalNumber = 0;
	int power = 1;
	for (int i = 0; i < length - 1; ++i)
	{
		decimalNumber += sum[i] * power;
		power *= 2;
	}
	return decimalNumber;
}

int intoDecimalNegativeNumber(bool sum[])
{
	reverse(sum);
	int decimalNumber = 0;
	int power = 1;
	for (int i = 0; i < length - 1; ++i)
	{
		decimalNumber += (!sum[i]) * power;
		power *= 2;
	}
	decimalNumber = -decimalNumber - 1;
	return decimalNumber;
}

int intoDecimalNumber(bool sum[])
{
	int decimalSum = 0;
	if (sum[0] == 1)
	{
		decimalSum = intoDecimalNegativeNumber(sum);
	}
	else if (sum[0] == 0)
	{
		decimalSum = intoDecimalPositiveNumber(sum);
	}
	return decimalSum;
}

bool test1()
{
	bool num1[length] = {};
	bool num2[length] = {};
	bool sum[length] = {};
	int a = 0;
	int b = 0;
	intoBinaryNumber(num1, a);
	intoBinaryNumber(num2, b);
	binarySum(num1, num2, sum);
	return (intoDecimalNumber(sum) == 0);
}

bool test2()
{
	bool num1[length] = {};
	bool num2[length] = {};
	bool sum[length] = {};
	int a = 975;
	int b = 24462;
	intoBinaryNumber(num1, a);
	intoBinaryNumber(num2, b);
	binarySum(num1, num2, sum);
	return (intoDecimalNumber(sum) == 25437);
}

bool test3()
{
	bool num1[length] = {};
	bool num2[length] = {};
	bool sum[length] = {};
	int a = -42;
	int b = 42;
	intoBinaryNumber(num1, a);
	intoBinaryNumber(num2, b);
	binarySum(num1, num2, sum);
	return (intoDecimalNumber(sum) == 0);
}

bool test4()
{
	bool num1[length] = {};
	bool num2[length] = {};
	bool sum[length] = {};
	int a = -65;
	int b = -98920;
	intoBinaryNumber(num1, a);
	intoBinaryNumber(num2, b);
	binarySum(num1, num2, sum);
	return (intoDecimalNumber(sum) == -98985);
}

bool test5()
{
	bool num1[length] = {};
	bool num2[length] = {};
	bool sum[length] = {};
	int a = -100;
	int b = 46;
	intoBinaryNumber(num1, a);
	intoBinaryNumber(num2, b);
	binarySum(num1, num2, sum);
	return (intoDecimalNumber(sum) == -54);
}

void main()
{
	setlocale(LC_ALL, "Russian");

	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;
	cout << "Test 3: " << test3() << endl;
	cout << "Test 4: " << test4() << endl;
	cout << "Test 5: " << test5() << endl;


	bool num1[length] = {};
	bool num2[length] = {};
	bool sum[length] = {};
	int a = 0;
	int b = 0;
	cout << "Введите числа A и B" << endl;
	cin >> a >> b;

	intoBinaryNumber(num1, a);
	intoBinaryNumber(num2, b);
	
	cout << "A = ";
	printNumber(num1);
	cout << endl;

	cout << "B = ";
	printNumber(num2);
	cout << endl;

	binarySum(num1, num2, sum);
	cout << "Двоичная сумма в дополнительном коде = ";
	printNumber(sum);
	cout << endl;

	cout << "Десятичная сумма = " << intoDecimalNumber(sum) << endl;
}