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

void inputArray(int *array, int lengthArray, int maxValue)
{
	srand(time(nullptr));
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = rand() % (maxValue + 1);
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

int frequentElement(int *array, int lastIndex)
{
	int freqElement = 0;
	int element = 0;
	int currentElement = 0;
	int currentFreq = 0;
	for (int i = 0; i <= lastIndex; ++i)
	{
		if (array[i] != currentElement)
		{
			currentElement = array[i];
			currentFreq = 0;
		}
		++currentFreq;
		if (currentFreq > freqElement)
		{
			element = currentElement;
			freqElement = currentFreq;
		}
	}
	return element;
}

bool test1()
{
	const int lengthArray = 10;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = i;
	}
	qSort(array, 0, lengthArray - 1);
	return frequentElement(array, lengthArray - 1) == 0;
}

bool test2()
{
	const int lengthArray = 10;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = lengthArray - i;
	}
	array[7] = 5;
	qSort(array, 0, lengthArray - 1);
	return frequentElement(array, lengthArray - 1) == 5;
}

bool test3()
{
	const int lengthArray = 10;
	int array[lengthArray] = {};
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = 10;
	}
	qSort(array, 0, lengthArray - 1);
	return frequentElement(array, lengthArray - 1) == 10;
}

bool test4()
{
	const int lengthArray = 10;
	int array[lengthArray] = { 1, 2, 3, 3, 3, 4, 4, 4, 4, 4 };
	qSort(array, 0, lengthArray - 1);
	return frequentElement(array, lengthArray - 1) == 4;
}

bool test5()
{
	const int lengthArray = 10;
	int array[lengthArray] = { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
	qSort(array, 0, lengthArray - 1);
	return frequentElement(array, lengthArray - 1) == 4;
}

void main()
{
	const int maxValue = 100;
	int lengthArray = 0;
	cout << "Test 1: " << test1() << endl;
	cout << "Test 2: " << test2() << endl;
	cout << "Test 3: " << test3() << endl;
	cout << "Test 4: " << test4() << endl;
	cout << "Test 5: " << test5() << endl;
	cout << endl;
	cout << "Enter the length of array" << endl;
	cin >> lengthArray;
	int *array = new int[lengthArray] {};
	cout << "Array of " << lengthArray << " elements:" << endl;
	inputArray(array, lengthArray, maxValue);
	printArray(array, lengthArray);
	cout << endl;
	cout << "Sorted array:" << endl;
	qSort(array, 0, lengthArray - 1);
	printArray(array, lengthArray);
	cout << endl;
	cout << "Answer: " << frequentElement(array, lengthArray) << endl;
	delete[] array;
	array = nullptr;
}