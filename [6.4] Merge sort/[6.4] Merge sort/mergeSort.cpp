#include <iostream>
#include <string>
#include "mergeSort.h"
#include "list.h"

using namespace std;

List *split(List *list)
{
	const int sizeOfList = getSize(list) / 2;
	auto splitedList = createList();

	for (int i = 0; i < sizeOfList; ++i)
	{
		const string name = getNameFromHead(list);
		const string phone = getPhoneFromHead(list);
	}

	return splitedList;
}

List *merge(List *&leftHalf, List *rightHalf, const short sortType)
{

}

void mergeSort(List *&list, const short sortType)
{
	if (getSize(list) <= 1)
	{
		return;
	}

	auto leftHalf = list;
	auto rightHalf = split(list);

	mergeSort(leftHalf, sortType);
	mergeSort(rightHalf, sortType);

	list = merge(leftHalf, rightHalf, sortType);
}

