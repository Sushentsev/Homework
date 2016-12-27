#pragma once
#include <fstream>

/* The structure of country */
struct Country;

/* Creating country */
Country *createCountries(int size);

/* Reading graph from file */
void readGraphFromFile(Graph *graph, std::ifstream &file, int m);

/* Checking if city and capital belong to one country */
bool isContained(Country *country, int capital, int city, int numberOfCapitals);

/* Getting array of countries */
void getCountries(Graph *&graph, Country *country, int numberOfCapitals);

/* Reading capitals from file */
void readCapitalsFromFile(Country *country, std::ifstream &file, int k);

/* Printing countries */
void printCountries(Country *country, int k);

/* Removing countries */
void removeCountries(Country *&country, int k);