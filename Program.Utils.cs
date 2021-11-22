using System.Reflection;
using System.Runtime.InteropServices;

partial class Program
{
    // NOTE: Library resolver function may contain logic to return different libraries.
    // Parameters:
    //   name - Name of requested library (defined in 'DllImport' attribute)
    //   asm  - .NET assembly which requested library
    //   path - some options to search libraries
    static IntPtr ResolveLib(string name, Assembly asm, DllImportSearchPath? path) => 
        NativeLibrary.Load(ExePath() + name + DllExtension());

    // Returns dynamic library extension for current environment
    static string DllExtension()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return ".dll";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return ".so";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return ".dylib";
        throw new Exception($"OS is not supported: {Environment.OSVersion.VersionString}");
    }

    // Returns folder where executing program (and libraries) is located
    static string ExePath() => AppDomain.CurrentDomain.BaseDirectory;
}