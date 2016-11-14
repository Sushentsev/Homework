#include "qSort.h"

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
				int a = array[l];
				array[l] = array[r];
				array[r] = a;
				++l;
				--r;
			}
		}
		qSort(array, left, r);
		qSort(array, l, right);
	}
}