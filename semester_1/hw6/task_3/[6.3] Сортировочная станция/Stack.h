#pragma once

/* Описание структуры элемента стека */
struct StackElement;

/* Описание структуры стека */
struct Stack;

/* Создание стека */
Stack* createStack();

/* Проверка стека на пустоту */
bool isEmpty(Stack *stack);

/* Добавление элемента в стек */
void push(Stack *stack, char value);

/* Удаление элемента из стека */
char pop(Stack *stack);

/* Удаление стека */
void deleteStack(Stack *&stack);
