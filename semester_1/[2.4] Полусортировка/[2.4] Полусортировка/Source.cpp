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
	cout << endl;
}

void inputArray(int *array, int lengthArray)
{
	srand(time(nullptr));
	for (int i = 0; i < lengthArray; ++i)
	{
		array[i] = rand() % 11;
	}
}

int changeArray(int *array, int lengthArray)
{
	int left = 0;
	int right = lengthArray - 1;
	while (right > left)
	{
		while (array[0] < array[right])
		{
			--right;
		}

		while (array[0] >= array[left])
		{
			++left;
		}

		if (left >= right)
		{
			return 0;
		}
		swap(array[left], array[right]);
	}
}

void main()
{
	int lengthArray = 0;
	cout << "Enter the length of array" << endl;
	cin >> lengthArray;
	int *array = new int[lengthArray];
	inputArray(array, lengthArray);
	cout << "Random array of " << lengthArray << " elements:" << endl;
	printArray(array, lengthArray);
	changeArray(array, lengthArray);
	cout << "New array:" << endl;
	printArray(array, lengthArray);
	cout << endl;
	cout << "Thank you for watching!" << endl;
	cout << endl;
	delete[] array;
}