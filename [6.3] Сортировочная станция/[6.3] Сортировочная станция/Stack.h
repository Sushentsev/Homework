#pragma once

struct StackElement;
struct Stack;
Stack* createStack();
bool isEmpty(Stack *stack);
void push(Stack *stack, char value);
char pop(Stack *stack);
void deleteStack(Stack *stack);
