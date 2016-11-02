#include <iostream>
using namespace std;

int main()
{
	int x = 0, sum = 0;
	cout << "Enter X" << endl;
	cin >> x;
	int squareX = x * x;
	sum = (squareX + 1) * (squareX + x) + 1;
	cout << "The result is " << sum << endl;
	system("pause");
	return 0;
}