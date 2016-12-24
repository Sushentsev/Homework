#pragma once

/* Описание структуры элемента */
struct StackElement;

/* Описание структуры стека */
struct Stack;

/* Создание стека */
Stack* createStack();

/* Проверка стека на пустоту */
bool isEmpty(Stack *stack);

/* Добавление значения в стек */
void push(Stack *stack, int value);

/* Удаление значения из стека */
int pop(Stack *stack);

/* Удаление стека */
void deleteStack(Stack *&stack);
