#pragma once
#include <string>

using namespace std;

/* �������� ��������� ��� */
void loadStatesFromFIle(int stateTable[3][4]);

/* ������ ���� ������������ � ������ */
void readComments(int stateTable[3][4], const string &fileName, string &comments);