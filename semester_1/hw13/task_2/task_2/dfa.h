#pragma once
#include <string>

/* Loading states from file */
void loadStatesFromFIle(int stateTable[3][4]);

/* Reading all comments */
void readComments(const int stateTable[3][4], const std::string &fileName, std::string &comments);