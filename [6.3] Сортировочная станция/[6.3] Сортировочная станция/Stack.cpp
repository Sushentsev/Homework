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
	auto stack = new Stack{ nullptr, 0 };
	return stack;
}

bool isEmpty(Stack *stack)
{
	return stack->length == 0;
}

void push(Stack *stack, char value)
{
	auto newElement = new StackElement{ value, stack->head };
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
	auto toDelete = stack->head;
	stack->head = stack->head->next;
	delete toDelete;
	--stack->length;
	return value;
}

void deleteStack(Stack *&stack)
{
	while (stack->head != nullptr)
	{
		StackElement *toDelete = stack->head;
		stack->head = stack->head->next;
		delete toDelete;
	}
	delete stack;
	stack = nullptr;
}