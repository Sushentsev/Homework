#include <iostream>
#include "Stack.h"
#include <string>

void fromInfixFormToPostFix(const std::string &infixForm, std::string &postfixForm)
{

}

void main()
{
	setlocale(LC_ALL, "Russian");
	Stack *stack = createStack();
	std::string infixForm = "";
	std::string postfixForm = "";
	std::cout << "������� ��������� � ��������� �����:" << std::endl;
	std::getline(std::cin, infixForm);
	infixForm = infixForm + "|";
	fromInfixFormToPostFix(infixForm, postfixForm);
	std::cout << "����������� ����� ���������: " << postfixForm << std::endl;
	delete stack;
	stack = nullptr;
}