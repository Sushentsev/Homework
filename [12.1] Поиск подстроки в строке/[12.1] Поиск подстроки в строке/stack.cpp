#include <iostream>
#include <string>
#include "stack.h"

struct StackElement
{
	char symbol;
	int value;
	StackElement *next;
};

struct Stack
{
	StackElement *head;
};

Stack* createStack()
{
	Stack *stack = new Stack;
	stack->head = nullptr;
	return stack;
}

StackElement* createStackElement(StackElement *next, char symbol, int value)
{
	StackElement *newStackElement = new StackElement;
	newStackElement->symbol = symbol;
	newStackElement->value = value;
	newStackElement->next = next;
	return newStackElement;
}

bool isEmpty(Stack *stack)
{
	return stack->head == nullptr;
}

bool isContained(Stack *stack, char symbol)
{
	StackElement *cursor = stack->head;
	while (cursor != nullptr)
	{
		if (cursor->symbol == symbol)
		{
			return true;
		}
		cursor = cursor->next;
	}
	return false;
}

void push(Stack *stack, char symbol, int value)
{
	stack->head = createStackElement(stack->head, symbol, value);
}

void pop(Stack *stack)
{
	if (isEmpty(stack))
	{
		return;
	}
	else
	{
		StackElement *toDelete = stack->head;
		stack->head = stack->head->next;
		delete toDelete;
		toDelete = nullptr;
	}
}

int returnValue(Stack *stack, char symbol)
{
	StackElement *cursor = stack->head;
	while (cursor->symbol != symbol)
	{
		cursor = cursor->next;
	}
	return cursor->value;
}

void deleteStack(Stack *stack)
{
	while (!isEmpty(stack))
	{
		pop(stack);
	}
	delete stack;
	stack = nullptr;
}

void printStack(Stack *stack)
{
	StackElement *cursor = stack->head;
	while (cursor != nullptr)
	{
		std::cout << "Symbol: " << cursor->symbol << " Value: " << cursor->value << std::endl;
		cursor = cursor->next;
	}
}