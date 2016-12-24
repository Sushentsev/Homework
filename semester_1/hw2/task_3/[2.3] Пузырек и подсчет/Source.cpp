#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

void printArr(int *arr, int lengthArr)
{
	for (int i = 0; i < lengthArr; ++i)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}

void randomArr(int *arr, int lengthArr, int max)
{
	cout << "The array of random digits:" << endl;
	srand(time(nullptr));
	for (int i = 0; i <= lengthArr - 1; ++i)
	{
		arr[i] = rand() % (max + 1);
		cout << arr[i] << " ";
	}
	cout << endl;
}

void bubbleSort(int *arr, int length)
{
	for (int i = 0; i < length - 1; ++i)
	{
		for (int j = 0; j < length - i - 1; ++j)
		{
			if (arr[j] > arr[j + 1])
			{
				int a = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = a;
			}
		}
	}
}


void countingSort(int *arr, int min, int max, int length)
{
	int *countingArr = new int[max + 1]{};
	int number = 0;
	for (int i = 0; i < length; ++i)
	{
		++countingArr[arr[i]];
	}
	for (int i = min; i <= max; ++i)
	{
		for (int j = 0; j < countingArr[i]; ++j)
		{
			arr[number] = i;
			++number;
		}
	}
	delete[] countingArr;
}

void main()
{
	const int max = 30;
	const int min = 0;
	int lengthArr = 0;
	cout << "Enter the length of array" << endl;
	cin >> lengthArr;
	int *arrBubble = new int[lengthArr];
	int *arrCounting = new int[lengthArr];

	randomArr(arrBubble, lengthArr, max);
	bubbleSort(arrBubble, lengthArr);
	cout << "New array [bubble sort]:" << endl;
	printArr(arrBubble, lengthArr);
	cout << endl;
	randomArr(arrCounting, lengthArr, max);
	countingSort(arrCounting, min, max, lengthArr);
	cout << "New array [counting sort]:" << endl;
	printArr(arrCounting, lengthArr);

	delete[] arrBubble;
	delete[] arrCounting;
}