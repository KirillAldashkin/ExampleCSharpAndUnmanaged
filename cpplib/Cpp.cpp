#define DLL_EXPORT extern "C" __declspec(dllexport)
#include <iostream>
#include <cmath>

using namespace std;

DLL_EXPORT void squareRoot(double* val)
{
	cout << "[C++] Value: " << *val << endl;
	*val = sqrt(*val);
	cout << "[C++] Square root: " << *val << endl;
}
