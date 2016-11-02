#pragma once

struct StackElement;
struct Stack;
Stack* createStack();
bool isEmpty(Stack *stack);
void push(Stack *stack, char value);
int pop(Stack *stack);
void deleteStack(Stack *stack);
