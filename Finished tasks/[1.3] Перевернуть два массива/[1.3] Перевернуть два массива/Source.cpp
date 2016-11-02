#include <iostream>

using namespace std;

void printArr(int *newArr, int firstElement, int lastElement)
{
	for (int i = firstElement; i <= lastElement; ++i)
	{
		cout << newArr[i] << " ";
	}
}

void changeArr(int *newArr, int first, int last)
{
	int k = 0;
	for (int i = first; i <= (last - first) / 2 + first; ++i)
	{
		swap(newArr[i], newArr[last - k]);
		++k;
	}
}

void main()
{
	int m = 0;
	int n = 0;
	cout << "Enter m and n" << endl;
	cin >> m >> n;
	int *newArr = new int[m + n];
	cout << "All elements of array:" << endl;
	for (int i = 0; i <= m + n - 1; ++i)
	{
		newArr[i] = i;
		cout << i << " ";
	}
	cout << endl;
	changeArr(newArr, 0, m - 1);
	changeArr(newArr, m, m + n - 1);
	changeArr(newArr, 0, m + n - 1);
	cout << "New array:" << endl;
	printArr(newArr, 0, m + n - 1);
	cout << endl;
	delete[] newArr;
}