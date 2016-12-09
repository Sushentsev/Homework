#include <iostream>
#include <fstream>
#include <string>


void main()
{
	setlocale(LC_ALL, "Russian");
	std::string str = "";

	std::ifstream file("input.txt");
	if (file.is_open())
	{
		getline(file, str, '\0');
		file.close();
	}
	else
	{
		std::cout << "Ошибка при открытии файла" << std::endl;
	}

}