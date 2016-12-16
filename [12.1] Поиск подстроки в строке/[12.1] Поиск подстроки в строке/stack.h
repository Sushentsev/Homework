#pragma once

/* ��������� ����� */
struct Stack;

/* �������� ����� */
Stack* createStack();

/* �������� �� ������� */
bool isEmpty(Stack *stack);

/* ���������� �� �������� � ����� */
bool isContained(Stack *stack, char symbol);

/* ���������� �������� � ������ ����� */
void push(Stack *stack, const char symbol, int value);

/* �������� �������� �� ������ ����� */
void pop(Stack *stack);

/* ���������� �������� �������� */
int returnValue(Stack *stack, char symbol);

/* ������� ����� */
void deleteStack(Stack *stack);

void printStack(Stack *stack);