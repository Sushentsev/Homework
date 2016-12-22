#pragma once
#include <string>

using namespace std;

/* Загрузка состояний ДКА */
void loadStatesFromFIle(int stateTable[3][4]);

/* Запись всех комментариев в тексте */
void readComments(int stateTable[3][4], const string &fileName, string &comments);