#if _WIN32
#define DLL_EXPORT extern "C" __declspec(dllexport)
#else
#define DLL_EXPORT
#endif
#include <iostream>
#include <cmath>

using namespace std;

DLL_EXPORT void squareRoot(double* val)
{
	cout << "[C++] Value: " << *val << endl;
	*val = sqrt(*val);
	cout << "[C++] Square root: " << *val << endl;
}
