#pragma once
#include <string>

using namespace std;

/* Loading states from file */
void loadStatesFromFIle(int stateTable[3][4]);

/* Reading all comments */
void readComments(const int stateTable[3][4], const string &fileName, string &comments);