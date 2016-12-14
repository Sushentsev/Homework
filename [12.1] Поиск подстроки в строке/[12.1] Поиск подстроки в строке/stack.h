#pragma once

/* Структура стека */
struct Stack;

/* Создание стека */
Stack* createStack();

/* Проверка на пустоту */
bool isEmpty(Stack *stack);

/* Содержится ли значение в стеке */
bool isContained(Stack *stack, char symbol);

/* Добавление элемента в голову стека */
void push(Stack *stack, char symbol, int value);

/* Удаление элемента из головы стека */
void pop(Stack *stack);

/* Изменение значения элемента */
void changeValue(Stack *stack, char symbol, int value);

/* Возвращает значение элемента */
int returnValue(Stack *stack, char symbol);

/* Удалеие стека */
void deleteStack(Stack *stack);

void printStack(Stack *stack);