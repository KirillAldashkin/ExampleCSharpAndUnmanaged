using System.Reflection;
using System.Runtime.InteropServices;

// 0) Define external functions
// 'unsafe' keyword is used to allow pointers
[DllImport("libcpplib")]
static extern unsafe void squareRoot(double* val);

// 1) Create library resolver function
// NOTE: this fuction may contain logic to return different libraries.
// Parameters:
//   name - Name of requested library (defined in 'DllImport' attribute)
//   asm  - .NET assembly which requested library
//   path - some options to search libraries
IntPtr ResolveLib(string name, Assembly asm, DllImportSearchPath? path) => NativeLibrary.Load(name);

// 2) Register library resolver function
NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), ResolveLib);

// 3) Use exteral functions
unsafe
{
    double val = 25;
    Console.WriteLine($"[C#] Value: {val}");
    squareRoot(&val);
    Console.WriteLine($"[C#] Value: {val}");
    squareRoot(&val);
    Console.WriteLine($"[C#] Value: {val}");
}