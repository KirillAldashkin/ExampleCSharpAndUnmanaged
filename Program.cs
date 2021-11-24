using System.Reflection;
using System.Runtime.InteropServices;

unsafe delegate int ComparerDelegate(void* l, void* r);
unsafe delegate int ComparerDelegateRef(object l, object r);
delegate double ConverterDelegate(double p);
delegate void FunctionReturn();

partial class Program
{
    // 1) Define external functions
    // see "Program.Externs.cs" to find definitions

    static void Main()
    {
        // 2) Register library resolver function (see "Program.Utils.cs" to find "ResolveLib"
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), ResolveLib);
        // 3) Use exteral functions (see "Program.Examples.cs" to find methods below)
        PointersExample();
        DelegatesToUnmanagedExample();
        UnmanagedToDelegatesExample();
        SortExample();
    }
}