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
	auto stack = new Stack{ nullptr, 0 };
	return stack;
}

bool isEmpty(Stack *stack)
{
	return stack->length == 0;
}

void push(Stack *stack, int value)
{
	auto newElement = new StackElement{ value, stack->head };
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
		auto toDelete = stack->head;
		stack->head = stack->head->next;
		delete toDelete;
	}
	delete stack;
	stack = nullptr;
}