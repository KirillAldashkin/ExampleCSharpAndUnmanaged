using System.Reflection;
using System.Runtime.InteropServices;

delegate double ConverterDelegate(double p);
delegate void FunctionReturn();

partial class Program
{
    // 1) Define external functions
    // 'unsafe' keyword is used to allow pointers
    [DllImport("libcpplib")]
    static extern unsafe void squareRoot(double* val);
    [DllImport("libcpplib")]
    static extern double sumFunc(double from, double to, double step, ConverterDelegate func);
    [DllImport("libcpplib")]
    static extern FunctionReturn getFunction(int value);

    static void Main()
    {
        // 2) Register library resolver function (see "Program.Utils.cs" to find "ResolveLib"
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), ResolveLib);
        // 3) Use exteral functions (see "Program.Examples.cs" to find methods below)
        PointersExample();
        DelegatesToUnmanagedExample();
        UnmanagedToDelegatesExample();
    }
}