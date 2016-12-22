#include <iostream>
#include <string>
#include "mergeSort.h"
#include "list.h"

void mergeSort(List *&list, bool sortType)
{
	if (listLength(list) < 2)
	{
		return;
	}
	auto firstHalf = list;
	auto secondHalf = findMiddle(list);
}