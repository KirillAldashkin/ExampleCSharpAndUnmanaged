# C# managed ↔ unmanaged code
### About
Demonstration of communication between managed code and unmanaged code. 
Shows how:
1) Load and unload libraries using [NativeLibrary](https://docs.microsoft.com/ru-ru/dotnet/api/system.runtime.interopservices.nativelibrary?view=net-6.0) class
2) Configure library resolver using [SetDllImportResolver](https://docs.microsoft.com/ru-ru/dotnet/api/system.runtime.interopservices.nativelibrary.setdllimportresolver?view=net-6.0)
3) Define external methods
### Building
**Required:**
1) [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) or later
2) [CMake 3.8](https://cmake.org/download/) or later
3) GNU C++ compiler

*NOTE* This project should be cross-platfrom, but I tested it only on Windows. Please 
[report](https://github.com/KirillAldashkin/ExampleCSharpAndUnmanaged/issues/new) 
about any building issues.

**Instructions:**
1) `cd` to repository folder
2) `dotnet build` to build or `dotnet run` to run. The build of CMake projects will be started automatically.