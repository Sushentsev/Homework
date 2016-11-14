#include <iostream>

struct ListElement
{
	int value;
	ListElement *next;
};

struct List
{
	ListElement *head;
};

List* createList()
{
	List *list = new List;
	list->head = nullptr;
	return list;
}

ListElement* createListElement(int value, ListElement *next)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = next;
	return newElement;
}

bool isEmpty(List *list)
{
	return list->head == nullptr;
}

void addElement(List *list, int value)
{
	if (isEmpty(list))
	{
		list->head = createListElement(value, nullptr);
		std::cout << "—оздан первый элемент" << std::endl;
		return;
	}

	ListElement *temp = list->head;
	if (temp->value > value)
	{
		temp = createListElement(value, temp);
		list->head = temp;
		std::cout << "Ёлемент успешно добавлен!" << std::endl;
		return;
	}
	while (temp->next != nullptr && temp->next->value < value)
	{
		temp = temp->next;
	}
	temp->next = createListElement(value, temp->next);
	std::cout << "Ёлемент успешно добавлен!" << std::endl;
}

void removeElement(List *list, int value)
{
	if (isEmpty(list))
	{
		std::cout << "—писок пуст!" << std::endl;
		return;
	}
	ListElement *temp = list->head;
	if (temp->next == nullptr && temp->value == value)
	{
		delete temp;
		temp = nullptr;
		list->head = nullptr;
		std::cout << "Ёлемент успешно удален!" << std::endl;
		return;
	}
	if (temp->value == value)
	{
		ListElement *toDelete = temp;
		list->head = temp->next;
		delete toDelete;
		toDelete = nullptr;
		std::cout << "Ёлемент успешно удален!" << std::endl;
		return;
	}
	while (temp->next != nullptr && temp->next->value != value)
	{
		temp = temp->next;
	}
	if (temp->next == nullptr)
	{
		std::cout << "“акого элемента нет" << std::endl;
		return;
	}
	ListElement *toDelete = temp->next;
	temp->next = temp->next->next;
	delete toDelete;
	toDelete = nullptr;
	std::cout << "Ёлемент успешно удален!" << std::endl;
}

void printList(List *list)
{
	if (isEmpty(list))
	{
		std::cout << "—писок пуст!" << std::endl;
		return;
	}
	ListElement *temp = list->head;
	while (temp->next != nullptr)
	{
		std::cout << temp->value << " ";
		temp = temp->next;
	}
	std::cout << temp->value << std::endl;
	std::cout << "¬се значени€ распечатаны!" << std::endl;
}

void deleteList(List *list)
{
	if (isEmpty(list))
	{
		return;
	}
	while (list->head != nullptr)
	{
		ListElement *toDelete = list->head;
		list->head = list->head->next;
		delete toDelete;
		toDelete = nullptr;
	}
	delete list;
	list = nullptr;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	List *list = createList();
	short selection = -1;
	while (selection != 0)
	{
		int value = 0;
		std::cout << "¬ыберете операцию:" << std::endl;
		std::cout << "0 Ц выйти" << std::endl;
		std::cout << "1 Ц добавить значение в сортированный список" << std::endl;
		std::cout << "2 Ц удалить значение из списка" << std::endl;
		std::cout << "3 Ц распечатать список" << std::endl;
		std::cout << std::endl;
		std::cin >> selection;
		switch (selection)
		{
		case 1:
			std::cout << "¬ведите значение добавл€емого элемента:" << std::endl;
			std::cin >> value;
			addElement(list, value);
			std::cout << std::endl;
			break;
		case 2:
			std::cout << "¬ведите значение удал€емого элемента:" << std::endl;
			std::cin >> value;
			removeElement(list, value);
			std::cout << std::endl;
			break;
		case 3:
			printList(list);
			std::cout << std::endl;
			break;
		default:
			break;
		}
	}
	deleteList(list);
}