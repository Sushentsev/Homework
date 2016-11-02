#include <iostream>
using namespace std;

int fibonacciRecursion(int n)
{
	if (n == 0 || n == 1)
	{
		return 1;
	}
	return fibonacciRecursion(n - 1) + fibonacciRecursion(n - 2);

}

int fibonacciIteration(int n)
{
	int firstNumber = 1, secondNumber = 1, thirdNumber = 1 + 1;
	if (n <= 1)
	{
		return 1;
	}
	else
	{
		for (int i = 2; i <= n; ++i)
		{
			firstNumber = secondNumber;
			secondNumber = thirdNumber;
			thirdNumber = firstNumber + secondNumber;
		}
		return secondNumber;
	}
}

int main()
{
	int n = 0;
	cout << "Enter N" << endl;
	cin >> n;
	cout << "Your Fibonacci number is " << fibonacciIteration(n) << " (iterative method)" << endl;
	cout << "Your Fibonacci number is " << fibonacciRecursion(n) << " (recursive method)" << endl;
	return 0;
}