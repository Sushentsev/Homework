#include "graph.h"
#include "list.h"
#include <fstream>
#include <iostream>

using namespace std;

struct Country
{
	int capital;
	ListElement *cities;
};

Country *createCountries(int size)
{
	return new Country[size]{ 0, nullptr };
}

bool isContained(Country *country, int capital, int city, int numberOfCapitals)
{
	int index = -1;
	for (int i = 0; i < numberOfCapitals; ++i)
	{
		if (country[i].capital == capital)
		{
			index = i;
			break;
		}
	}
	return isContained(country[index].cities, city);
}

void removeRoadsBetweenCapitals(Country *country, Graph *graph, int numberOfCapitals)
{
	for (int i = 0; i < numberOfCapitals; ++i)
	{
		for (int j = i; j < numberOfCapitals; ++j)
		{
			const int firstCapital = country[i].capital;
			const int secondCapital = country[j].capital;
			inputGraph(graph, firstCapital, secondCapital, 0);
		}
	}
}

bool isMinimumDistance(int distance, int minDistance)
{
	return ((distance > 0) && (distance < minDistance));
}

void inputArray(bool *freeCities, int numberOfCities)
{
	for (int i = 0; i < numberOfCities; ++i)
	{
		freeCities[i] = true;
	}
}

void markCapitals(Country *country, bool *freeCities, int numberOfCapitals, int &numberOfFreeCities)
{
	for (int i = 0; i < numberOfCapitals; ++i)
	{
		freeCities[country[i].capital] = false;
		--numberOfFreeCities;
	}
}

void getCountries(Graph *&graph, Country *country, int numberOfCapitals)
{
	removeRoadsBetweenCapitals(country, graph, numberOfCapitals);

	const int numberOfCities = sizeOfGraph(graph);
	auto freeCities = new bool[numberOfCities];
	inputArray(freeCities, numberOfCities);
	int numberOfFreeCities = numberOfCities;
	int capitalIndex = 0;
	markCapitals(country, freeCities, numberOfCapitals, numberOfFreeCities);

	while (numberOfFreeCities > 0)
	{
		capitalIndex = capitalIndex % numberOfCapitals;
		int minDistance = INT_MAX;
		int freeCity = -1;

		const int capital = country[capitalIndex].capital;
		for (int i = 0; i < numberOfCities; ++i)
		{
			int distance = getValue(graph, capital, i);
			if (freeCities[i] && isMinimumDistance(distance, minDistance))
			{
				freeCity = i;
				minDistance = distance;
			}
		}

		if (!isEmpty(country[capitalIndex].cities))
		{
			auto cursor = country[capitalIndex].cities;

			while (cursor != nullptr)
			{
				for (int i = 0; i < numberOfCities; ++i)
				{
					int distance = getValue(graph, getValue(cursor), i);
					if (freeCities[i] && isMinimumDistance(distance, minDistance))
					{
						freeCity = i;
						minDistance = distance;
					}
				}
				cursor = nextElement(cursor);
			}
		}

		if (freeCity >= 0)
		{
			addToHead(country[capitalIndex].cities, freeCity);
			for (int i = 0; i < numberOfCities; ++i)
			{
				if (!freeCities[i])
				{
					inputGraph(graph, i, freeCity, 0);
				}
			}
			freeCities[freeCity] = false;
			--numberOfFreeCities;
		}
		++capitalIndex;
	}
	delete freeCities;
}

void readGraphFromFile(Graph *graph, ifstream &file, int m)
{
	int i = 0;
	int j = 0;
	int len = 0;
	for (int k = 1; k <= m; ++k)
	{
		file >> i;
		file >> j;
		file >> len;
		inputGraph(graph, i, j, len);
	}
}

void readCapitalsFromFile(Country *country, ifstream &file, int k)
{
	for (int i = 0; i < k; ++i)
	{
		file >> country[i].capital;
		country[i].cities = nullptr;
	}
}

void printCountries(Country *country, int k)
{
	for (int i = 0; i < k; ++i)
	{
		cout << country[i].capital << "-> ";
		if (!isEmpty(country[i].cities))
		{
			printList(country[i].cities);
		}
		cout << endl;
	}
}

void removeCountries(Country *&country, int k)
{
	for (int i = 0; i < k; ++i)
	{
		removeList(country[i].cities);
	}
	delete country;
	country = nullptr;
}