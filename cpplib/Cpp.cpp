#include <iostream>
#include <cmath>

using namespace std;

void squareRoot(double* val)
{
	cout << "[C++] Value: " << val << endl;
	*val = sqrt(*val);
	cout << "[C++] Square root: " << val << endl;
}
