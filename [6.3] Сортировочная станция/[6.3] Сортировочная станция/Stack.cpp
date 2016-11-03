Skip to content
This repository
Search
Pull requests
Issues
Gist
@Sushentsev
Watch 1
Star 0
Fork 0 Sushentsev / Homework
Code  Issues 0  Pull requests 2  Projects 0  Wiki  Pulse  Graphs  Settings
Branch : task_6.2 Find file Copy pathHomework / [6.2] Баланс скобок / [6.2] Баланс скобок / Stack.cpp
	e35f041  19 hours ago
	@Sushentsev Sushentsev Checking for balanced parentheses in an expression using stack
	1 contributor
	RawBlameHistory
	62 lines(55 sloc)  950 Bytes
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

int pop(Stack *stack)
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