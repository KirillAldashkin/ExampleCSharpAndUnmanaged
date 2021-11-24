using System.Runtime.InteropServices;

partial class Program
{
    // 'unsafe' keyword is used to allow pointers
    [DllImport("libcpplib")]
    static extern unsafe void squareRoot(double* val);
    [DllImport("libcpplib")]
    static extern double sumFunc(double from, double to, double step, ConverterDelegate func);
    [DllImport("libcpplib")]
    static extern FunctionReturn getFunction(int value);
    [DllImport("libcpplib")]
    static extern unsafe void extSort(void* start, int length, int size, ComparerDelegate comp);
    
    // NOTE: create wrappers for unmanaged functions to make them easier to use
    static unsafe void StdSort<T>(Span<T> data) where T : unmanaged, IComparable<T>
    {
        static int comp(void* l, void* r) => ((T*)l)->CompareTo(*(T*)r);
        fixed (T* start = &data[0]) extSort(start, data.Length, sizeof(T), comp);
    }
}