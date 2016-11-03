#include "Stack.h"
#include <string>

struct StackElement
{
	char value;
	StackElement *next;
};

struct Stack
{
	StackElement *head;
	int length;
};

Stack* createStack()
{
	Stack *stack = new Stack;
	stack->head = nullptr;
	stack->length = 0;
	return stack;
}

bool isEmpty(Stack *stack)
{
	return stack->length == 0;
}

void push(Stack *stack, char value)
{
	StackElement *newElement = new StackElement;
	newElement->value = value;
	newElement->next = stack->head;
	stack->head = newElement;
	++stack->length;
}

char pop(Stack *stack)
{
	if (isEmpty(stack))
	{
		return -1;
	}
	char value = stack->head->value;
	StackElement *toDelete = stack->head;
	stack->head = stack->head->next;
	delete toDelete;
	toDelete = nullptr;
	--stack->length;
	return value;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *toDelete = stack->head;
		stack->head = stack->head->next;
		delete toDelete;
		toDelete = nullptr;
	}
}