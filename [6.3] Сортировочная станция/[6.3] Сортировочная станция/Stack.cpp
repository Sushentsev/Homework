#include "Stack.h"

struct StackElement
{
	int value;
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

void push(Stack *stack, int value)
{
	StackElement *newElement = new StackElement;
	newElement->value = value;
	newElement->next = stack->head;
	stack->head = newElement;
	++stack->length;
}

int pop(Stack *stack)
{
	if (isEmpty(stack))
	{
		return -1;
	}
	int value = stack->head->value;
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