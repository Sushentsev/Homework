#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;

void printArray(int *array, int lengthArray)
{
	for (int i = 0; i < lengthArray; ++i)
	{
		cout << array[i] << " ";
	}
}

void inputArray(int *array, int lengthArray, int max)
{
	srand(time(nullptr));
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = 1;
		for (int j = 1; j <= 3; ++j)
		{
			array[i] *= rand() % (max + 1);
		}
	}
}

void qSort(int *array, int left, int right)
{
	if (left < right)
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

bool binarySearch(int *array, int key, int left, int right)
{
	while (left <= right)
	{
		int index = (left + right) / 2;
		if (key == array[index])
		{
			return true;
		}
		if (key < array[index])
		{
			right = index - 1;
		}
		else
		{
			left = index + 1;
		}
	}
	return false;
}

int randomNumber(int max)
{
	int number = 1;
	for (int i = 1; i <= 3; ++i)
	{
		number *= rand() % (max + 1);
	}
	return number;
}

bool test1()
{
	const int lengthArray = 100;
	const int element = 99;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = i;
	}
	qSort(array, 0, lengthArray - 1);
	if (binarySearch(array, element, 0, lengthArray - 1))
	{
		return true;
	}
	return false;
}

bool test2()
{
	const int lengthArray = 100;
	const int element = 5;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = 10;
	}
	qSort(array, 0, lengthArray - 1);
	if (binarySearch(array, element, 0, lengthArray - 1))
	{
		return false;
	}
	return true;
}

bool test3()
{
	const int lengthArray = 100;
	const int element = 50;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = lengthArray - i;
	}
	qSort(array, 0, lengthArray - 1);
	if (binarySearch(array, element, 0, lengthArray - 1))
	{
		return true;
	}
	return false;
}

void main()
{
	const int max = 100;
	int lengthArray = 0;
	int amountNumbers = 0;
	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;
	cout << "Test 3: " << test3() << endl;
	cout << endl;
	cout << "Enter n and k" << endl;
	cin >> lengthArray >> amountNumbers;
	int *array = new int[lengthArray] {};
	inputArray(array, lengthArray, max);
	cout << "Array of " << lengthArray << " elements:" << endl;
	printArray(array, lengthArray);
	cout << endl;
	cout << "Sorted array:" << endl;
	qSort(array, 0, lengthArray - 1);
	cout << "Number(existance: true(1) or false(0)) " << endl;
	for (int i = 1; i <= amountNumbers; ++i)
	{
		int number = randomNumber(max);
		cout << number << "(" << binarySearch(array, number, 0, lengthArray - 1) << ") ";
	}
	cout << endl;
	delete[] array;
	array = nullptr;
}