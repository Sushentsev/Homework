#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

void printArray(int *array, int lengthArray)
{
	for (int i = 0; i < lengthArray; ++i)
	{
		cout << array[i] << " ";
	}
}

void inputArray(int *array, int lengthArray, int maxValue)
{
	srand(time(nullptr));
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = rand() % (maxValue + 1);
	}
}

void insertionSort(int *array, int left, int right)
{
	for (int i = left + 1; i <= right; ++i)
	{
		int k = i;
		while (array[k] < array[k - 1] && k != 0)
		{
			swap(array[k], array[k - 1]);
			--k;
		}
	}
}

void qSort(int *array, int left, int right)
{
	if (right - left + 1 < 10)
	{
		insertionSort(array, left, right);
	}
	else
	{
		int pivot = array[left + (right - left + 1) / 2];
		int l = left;
		int r = right;
		while (l <= r)
		{
			while (array[l] < pivot)
			{
				++l;
			}
			while (array[r] > pivot)
			{
				--r;
			}
			if (l <= r)
			{
				swap(array[l], array[r]);
				++l;
				--r;
			}
		}
		qSort(array, left, r);
		qSort(array, l, right);
	}
}

bool isSorted(int *array, int lengthArray)
{
	for (int i = 1; i < lengthArray; ++i)
	{
		if (array[i - 1] > array[i])
		{
			return false;
		}
	}
	return true;
}

void test1()
{
	const int lengthArray = 100;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = 10;
	}
	array[lengthArray / 2] = 25;
	qSort(array, 0, lengthArray - 1);
	cout << "Test 1: " << isSorted(array, lengthArray) << endl;
}

void test2()
{
	const int lengthArray = 100;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = lengthArray - i;
	}
	qSort(array, 0, lengthArray - 1);
	cout << "Test 2: " << isSorted(array, lengthArray) << endl;
}

void test3()
{
	const int lengthArray = 100;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = i;
	}
	qSort(array, 0, lengthArray - 1);
	cout << "Test 3: " << isSorted(array, lengthArray) << endl;
}

void main()
{
	int lengthArray = 0;
	int minValue = 0;
	int maxValue = 30;
	test1();
	test2();
	test3();
	cout << "Enter the length of array" << endl;
	cin >> lengthArray;
	int *array = new int[lengthArray] {};
	inputArray(array, lengthArray, maxValue);
	cout << "Array of " << lengthArray << " elements:" << endl;
	printArray(array, lengthArray);
	cout << endl;
	qSort(array, 0, lengthArray - 1);
	cout << "New array:" << endl;
	printArray(array, lengthArray);
	cout << endl;
	cout << "Sorted: " << isSorted(array, lengthArray) << endl;
	delete[] array;
	array = nullptr;
}