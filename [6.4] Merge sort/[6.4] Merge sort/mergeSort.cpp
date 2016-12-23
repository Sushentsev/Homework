#include <iostream>
#include <string>
#include "mergeSort.h"
#include "list.h"

using namespace std;

void cutFromFirstListToSecond(List *&firstList, List *&secondList)
{
	const string name = getNameFromHead(firstList);
	const string phone = getPhoneFromHead(firstList);
	removeFromHead(firstList);
	addToTale(secondList, name, phone);
}

List *split(List *list)
{
	const int size = sizeOfList(list) / 2;
	auto splitedList = createList();

	for (int i = 0; i < size; ++i)
	{
		cutFromFirstListToSecond(list, splitedList);
	}

	return splitedList;
}

List *merge(List *&leftHalf, List *rightHalf, const short sortType)
{
	auto mergedList = createList();

	//sortType is 0 if sort by name
	//sortType is 1 if sort by phone

	while (!isEmpty(leftHalf) && !isEmpty(rightHalf))
	{
		if (!sortType && (getNameFromHead(leftHalf) < getNameFromHead(rightHalf)) || 
			sortType && (getPhoneFromHead(leftHalf) < getPhoneFromHead(rightHalf)))
		{
			cutFromFirstListToSecond(leftHalf, mergedList);
		}
		else
		{
			cutFromFirstListToSecond(rightHalf, mergedList);
		}
	}

	if (!isEmpty(leftHalf))
	{
		const int size = sizeOfList(leftHalf);
		for (int i = 0; i < size; ++i)
		{
			cutFromFirstListToSecond(leftHalf, mergedList);
		}
	}
	else if (!isEmpty(rightHalf))
	{
		const int size = sizeOfList(rightHalf);
		for (int i = 0; i < size; ++i)
		{
			cutFromFirstListToSecond(rightHalf, mergedList);
		}
	}

	removeList(leftHalf);
	removeList(rightHalf);
	return mergedList;
}

void mergeSort(List *&list, const short sortType)
{
	if (sizeOfList(list) <= 1)
	{
		return;
	}

	auto leftHalf = list;
	auto rightHalf = split(list);

	mergeSort(leftHalf, sortType);
	mergeSort(rightHalf, sortType);

	list = merge(leftHalf, rightHalf, sortType);
}

