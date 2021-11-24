#if _WIN32
#define DLL_EXPORT extern "C" __declspec(dllexport)
#else
#define DLL_EXPORT extern "C" __attribute__((visibility("default")))
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

DLL_EXPORT double sumFunc(double from, double to, double step, double (*convFunc)(double))
{
	double ret = 0;
	while (from <= to) {
		ret += convFunc(from);
		from += step;
	}
	return ret;
}

void fizzBuzz() { cout << " [C++] FizzBuzz" << endl; }
void fizz() { cout << " [C++] Fizz" << endl; }
void buzz() { cout << " [C++] Buzz" << endl; }
void none() { cout << " [C++]" << endl; }
DLL_EXPORT void* getFunction(int value)
{
	if (value % 15 == 0) return (void*)fizzBuzz;
	else if (value % 5 == 0) return (void*)buzz;
	else if (value % 3 == 0) return (void*)fizz;
	else return (void*)none;
}